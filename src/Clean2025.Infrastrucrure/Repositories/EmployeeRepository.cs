using Clean2025.Domain.Employees;
using Clean2025.Domain.Repositories.EmpoloyeesRepository;
using Clean2025.Infrastrucrure.Context;
using GenericRepository;

namespace Clean2025.Infrastrucrure.Repositories
{
    public sealed class EmployeeRepository:Repository<Employee,AppDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
        
    }
}