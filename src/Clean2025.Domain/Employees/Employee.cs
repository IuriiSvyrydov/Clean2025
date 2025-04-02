using Clean2025.Domain.Abstractions;
using Clean2025.Domain.ValueObjects;
namespace Clean2025.Domain.Employees;

    public sealed class Employee : BaseEntity
    {
        public FirstName FirstName { get; set; } = default!;
        public LastName LastName { get; set; } = default!;
        public string FullName =>string.Join(" ", FirstName.Value,  LastName.Value);
        public DateTime BirthDate { get; set; }
       public Money Salary { get; set; } = default!;
    public TCNo TCNo { get; set; } = default!;
    public PersonalInfo PersonalInfo { get; set; } = default!;
       public Address Address { get; set; } = default!;

       public Employee(Guid id) : base(id)
       {
       }
       public Employee(Guid id, FirstName firstName, LastName lastName, DateTime birthDate, Money salary, TCNo tcno,  PersonalInfo personalInfo, Address address) 
       {
           FirstName = firstName;
           LastName = lastName;
           BirthDate = birthDate;
           Salary = salary;
        TCNo = tcno;
           PersonalInfo = personalInfo;
           Address = address;
       }
       public void UpdateSalary(Money salary)
       {
           Salary = salary;
       }
       public static Employee Create(Guid id, FirstName firstName, LastName lastName, DateTime birthDate, Money salary, TCNo tCNo)
       
           => new Employee(id, firstName, lastName, birthDate, salary,tCNo, new PersonalInfo(), new Address());
       
    }
   
