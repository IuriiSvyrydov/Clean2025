using Clean2025.Domain.ValueObjects;

namespace Clean2025.Domain.Employees
{
    public sealed record PersonalInfo
    {
        public TCNo? TCNo{get;set;}
        public Email Email { get; set; } = null!;
        public Phone? Phone{get;set;}
    }
}