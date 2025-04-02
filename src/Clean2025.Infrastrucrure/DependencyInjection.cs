using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Clean2025.Domain.Repositories.EmpoloyeesRepository;
using Clean2025.Infrastrucrure.Context;
using Clean2025.Infrastrucrure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
namespace Clean2025.Infrastrucrure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrucrure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.Scan(opt => opt.FromAssemblies(typeof(DependencyInjection).Assembly)
        .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
     );
        return services;
    }
}