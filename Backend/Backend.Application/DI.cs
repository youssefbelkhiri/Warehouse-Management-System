using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application
{
    public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediatR and FluentValidation
            var assembly = typeof(DI).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
