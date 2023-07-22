using Downing.Data.Models;
using Downing.Pages.Companies;

namespace Downing.Extensions
{
    public static class NewCompanyExtensions
    {
        public static Company ToCompany(this NewCompany newCompany)
        {
            return new Company
            {
                CompanyName = newCompany.Name,
                Code = newCompany.Code.ToUpper(),
                SharePrice = string.IsNullOrEmpty(newCompany.SharePrice) ? default : Convert.ToDecimal(newCompany.SharePrice),
                CreatedDate = DateTime.Now
            };
        }
    }
}
