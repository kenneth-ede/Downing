
namespace Downing.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Decimal? SharePrice { get; set; }
    }
}
