using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyEmailMaketing.Models;
using MyEmailMaketing.Repository.Interfaces;

namespace MyEmailMaketing.Repository.DependencyInjection
{
    public static class InjectionRepositoryExtension
    {
        public static void DependencyInjectionRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICustomerRepos, CustomerRepos>();
            services.AddSingleton<IEmailRepos, EmailRepos>();
        }
    }
}
