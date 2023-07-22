
namespace Downing.Data.Models
{
    public class Investor
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public Company Company { get; set; }
    }
}
