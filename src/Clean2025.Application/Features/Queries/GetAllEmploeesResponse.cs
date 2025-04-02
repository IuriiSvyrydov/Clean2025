using Clean2025.Domain.Abstractions;

namespace Clean2025.Application.Features.Queries
{
    public class GetAllEmploeesResponse : EntityDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public string TCNo { get; set; } = default!;
       
    }
}