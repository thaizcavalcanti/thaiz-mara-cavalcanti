using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Exemplo.Repository.Data.Contexts;
using Exemplo.Repository.Data.Repositories;

namespace Exemplo.Repository
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options => options.UseLazyLoadingProxies().UseSqlServer(configuration.GetValue<string>("CONNECTION_STRING")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IContatoRepository, ContatoRepository>();    
    }
}
