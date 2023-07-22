using Downing.Data;
using Downing.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Downing.Pages.Companies
{
    public class AddModel : PageModel
    {
        private readonly IDbContextFactory<DatabaseContext> _contextFactory;

        [BindProperty]
        public NewCompany NewCompany { get;set; } = new NewCompany();

        public string ErrorMessage { get; set; } = String.Empty;

        public AddModel(IDbContextFactory<DatabaseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = String.Empty;
                return Page();
            }

            using var db = _contextFactory.CreateDbContext();

            if (await CompanyQueries.CompanyExists(db, NewCompany.Name))
            {
                ErrorMessage = Error.CompanyExists;
                return Page();
            }

            await CompanyQueries.AddCompany(db, NewCompany);

            return RedirectToPage(PageNames.Companies);
        }
    }

    public class NewCompany
    {
        [Required(ErrorMessage = Error.Name)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = Error.Code)]
        [RegularExpression(RegExes.AlphaNumeric, ErrorMessage = Error.CodeAlphaNumeric)]
        [MaxLength(10, ErrorMessage = Error.Max10)]
        public string Code { get; set; }

        [RegularExpression(RegExes.SharePrice, ErrorMessage = Error.SharePrice)]
        public string? SharePrice { get; set; }
    }
}
