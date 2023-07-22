using Downing.Data;
using Downing.Extensions;
using Downing.Models;
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
    }
}
