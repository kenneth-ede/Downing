using Downing.Data;
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

        public string ErrorMessage { get; set; } = string.Empty;

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
                return Page();


            return RedirectToPage(PageNames.Companies);
        }
    }

    public class NewCompany
    {
        [Required(ErrorMessage = Error.Name)]
        [RegularExpression(RegExes.All)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = Error.Code)]
        [RegularExpression(RegExes.AlphaNumeric)]
        [MaxLength(10, ErrorMessage = Error.Max10)]
        public string Code { get; set; }

        [RegularExpression(RegExes.Decimal)]
        public decimal? SharePrice { get; set; }
    }
}
