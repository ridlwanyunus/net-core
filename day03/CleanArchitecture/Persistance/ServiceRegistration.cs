using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Application.Repositories;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<SchoolContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("LocalDBConnection"),
                    x => x.MigrationsHistoryTable("_migrationHistory", "ridlwan")
                )
            );
            services.AddScoped(typeof(IRepositoriy<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static void Migrate(this IHost app)
        {
            using (var scope = app.Services.CreateScope()) 
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SchoolContext>();
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
        }

    }
}
