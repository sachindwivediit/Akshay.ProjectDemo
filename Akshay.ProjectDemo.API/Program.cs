
using Akshay.ProjectDemo.Entities;
using Akshay.ProjectDemo.Repository;
using Akshay.ProjectDemo.Repository.Implementation;
using Akshay.ProjectDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Akshay.ProjectDemo.API
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

            //pass conecctionstrings in constructor 
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Akshay.ProjectDemo.API")));
            //Add Generic repo
            //builder.Services.AddScoped(typeof(IGenericRepo<Country>), typeof(GenericRepo<Country>));

            // Add generic repository
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

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
