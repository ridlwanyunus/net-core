
using EntityFramworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramworkApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SchoolContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("LocalDBConnection"), 
                    x => x.MigrationsHistoryTable("_migrationHistory", "ridlwan")
                )
            );

            

            var a = builder.Configuration["MyCustomVariable:MyAppName"];
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
