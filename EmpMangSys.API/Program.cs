
using EmpMangSys.Api.Helper;
using EmpMangSys.Core.Interface;
using EmpMangSys.Repository.DataBaseContext;
using EmpMangSys.Repository.Interface_Implementations;
using Microsoft.EntityFrameworkCore;

namespace EmpMangSys.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            #region Configure Service Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BadrGroupDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            #endregion

            var app = builder.Build();

            #region Update DataBase
            // i will do it latter 
            #endregion
            #region Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
