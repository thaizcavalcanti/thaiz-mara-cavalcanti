using Exemplo.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo.Api.Config
{
    public static class ConfigServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<IContatoService, ContatoService>();
    }
}
