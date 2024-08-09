using Application.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<CourseFeature>();
            services.AddScoped<StudentFeature>();
            services.AddScoped<TokenFeature>();
            services.AddScoped<PasswordFeature>();
            services.AddScoped<IPasswordHasher<Object>, PasswordHasher<Object>>();
            services.AddScoped<AuthFeature>();
            services.AddScoped<ISieveProcessor, SieveProcessor>();
            return services;
        }
    }
}
