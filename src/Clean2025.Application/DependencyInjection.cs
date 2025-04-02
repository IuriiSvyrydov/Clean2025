using FluentValidation;
using Clean2025.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Clean2025.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(conf=>
            {
                conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}