using Downing.Data.Models;
using Downing.Models;

namespace Downing.Extensions
{
    public static class CompanyExtensions
    {
        public static IEnumerable<CompanyViewModel> ToCompanyViewModels(this IEnumerable<Company> companies)
        {
            return companies
                .OrderBy(x => x.CompanyName)
                .Select(x => new CompanyViewModel 
                { 
                    Name = x.CompanyName,
                    Code = x.Code,
                    Created = x.CreatedDate?.ToString("dd-MMM-yyyy"),
                    CurrentSharePrice = x.SharePrice?.ToString("0.00000")
                })
                .ToArray();
        }
    }
}
