
using MediatR;

namespace Clean2025.Application.Features.Queries;

    public record GetAllEmployeesQuery:IRequest<IQueryable<GetAllEmploeesResponse>>;
    
        
    
