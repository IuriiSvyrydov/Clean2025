using Clean2025.Domain.Employees;
using Clean2025.Domain.Repositories.EmpoloyeesRepository;
using MediatR;
using TS.Result;
using Mapster;
using GenericRepository;
namespace Clean2025.Application.Features.Empoloyees.Commands.CreateEmployee
{
    internal sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<string>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<Result<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isEmployeeExists = await _employeeRepository.AnyAsync(x => x.PersonalInfo.TCNo == request.PersonalInfo.TCNo,
         cancellationToken);
            if (isEmployeeExists)
            {
                return Result<string>.Failure("Employee already exists");
            }
            Employee employee = request.Adapt<Employee>();
            _employeeRepository.Add(employee);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return "Employee created successfully";
        }
    }
}