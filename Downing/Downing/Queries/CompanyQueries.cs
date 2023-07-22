using Downing.Data;
using Downing.Extensions;
using Downing.Models;
using Downing.Pages.Companies;
using Microsoft.EntityFrameworkCore;

namespace Downing.Queries
{
    public static class CompanyQueries
    {
        public async static Task<IEnumerable<CompanyViewModel>> AllCompanies(DatabaseContext db)
        {
            var companies = await db.Companies
                .AsNoTracking()
                .ToArrayAsync();

            return companies.ToCompanyViewModels();
        }

        public static async Task AddCompany(DatabaseContext db, NewCompany newCompany)
        {
            var company = newCompany.ToCompany();

            db.Companies.Add(company);

            await db.SaveChangesAsync();
        }

        public static async Task<bool> CompanyExists(DatabaseContext db, string name)
        {
            return await db.Companies.AnyAsync(x => x.CompanyName == name);
        }
    }
}
