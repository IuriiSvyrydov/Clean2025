
using Clean2025.Domain.Repositories.EmpoloyeesRepository;
using MediatR;

namespace Clean2025.Application.Features.Queries;
internal sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery,IQueryable< GetAllEmploeesResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

   public  Task<IQueryable<GetAllEmploeesResponse>>Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var response =  _employeeRepository.GetAll()
        .Select(x => new GetAllEmploeesResponse
        {

            FirstName =x.FirstName.Value,
            LastName = x.LastName.Value,
            BirthDate = x.BirthDate,
            Salary = x.Salary.Value,
            TCNo = x.TCNo.Value
        }).AsQueryable();
        return Task.FromResult(response);
        

    }
}
