using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TourRequest : BaseEntity
    {
        public string? Code { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyPhone { get; set; }
        public string? RequesterName { get; set; }
        public string? RequesterEmail { get; set; } 
        public string? RequesterPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PeopleNumber { get; set; }
        public decimal BudgetPerPerson { get; set; }
        public string? LocalTarget { get; set; }
        public string? HotelRank { get; set; }
        public string? Note { get; set; }
        public string? EstimateCost { get; set; }
        public DateTime RequestDate { get; set; }
        public int Status { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
