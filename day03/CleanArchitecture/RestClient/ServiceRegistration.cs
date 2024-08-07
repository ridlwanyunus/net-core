using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using RestClient.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRestClient(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IPlaceholderUserRepository, PlaceholderUserRepository> ();
            services.AddSingleton<RestClient>();
            return services;
        }
    }
}
