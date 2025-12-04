using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization; // ¡AÑADE ESTE USING!

namespace Zoologico1_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Zoologico1_APIContext>(options =>
                //options.UseSqlServer(builder.Configuration.GetConnectionString("Zoologico1_APIContext.sqlserver") ?? throw new InvalidOperationException("Connection string 'Zoologico1_APIContext' not found.")));
                options.UseNpgsql(builder.Configuration.GetConnectionString("Zoologico1_ApiContext.postgres") ?? throw new InvalidOperationException("Connection string 'Zoologico1_ApiContext.postgress' not found.")
        //        options.UseMySql(
        //builder.Configuration.GetConnectionString("Zoologico1_ApiContext.mariadb") 
        //?? throw new InvalidOperationException("Connection string 'Zoologico1_APIContext' not found."),
        //            Microsoft.EntityFrameworkCore.ServerVersion.Parse("12.0.2-MariaDB")



        ));

            // Add services to the container.

            // CONFIGURACIÓN CORRECTA - SOLO UNA VEZ
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure JSON options
            builder.Services
                .AddControllers()
                .AddNewtonsoftJson(
                    options =>
                    options.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
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