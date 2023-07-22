using Downing.Data;
using Downing.Models;
using Downing.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Downing.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly IDbContextFactory<DatabaseContext> _dbContextFactory;

        public IEnumerable<CompanyViewModel> Companies { get; set; }

        public IndexModel(IDbContextFactory<DatabaseContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            using var db = _dbContextFactory.CreateDbContext();

            Companies = await CompanyQueries.AllCompanies(db);

            return Page();
        }
    }
}
