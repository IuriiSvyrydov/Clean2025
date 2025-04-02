

using Clean2025.Domain.Employees;
using Clean2025.Domain.ValueObjects;
using MediatR;
using TS.Result;

namespace Clean2025.Application.Features.Empoloyees.Commands.CreateEmployee;

    public sealed record CreateEmployeeCommand(
        
        string FirstName,
        string LastName,
        DateTime BirthDate,
        decimal Salary,
        PersonalInfo PersonalInfo,
        Address Address
    ) : IRequest<Result<string>>;
    
