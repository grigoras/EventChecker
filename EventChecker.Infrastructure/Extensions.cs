using EventChecker.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EventChecker.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddScoped<IVisitRepository, VisitRepository>();
            service.AddScoped<ICookieRepository, CookieRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            return service;
        }
    }
}