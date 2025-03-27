using Lab1.Models;
using Lab1.Repositories;
using Lab1.Services;
using Microsoft.EntityFrameworkCore;

namespace Lab1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        // builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<SDbContext>(options => {
            options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies();
        });
        
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        // builder.Services.AddScoped<DepartmentRepository, DepartmentRepository>();
        // builder.Services.AddScoped<StudentRepository, StudentRepository>();
        builder.Services.AddScoped(typeof(Repository<>), typeof(Repository<>));
        builder.Services.AddScoped<DepartmentService, DepartmentService>();
        builder.Services.AddScoped<StudentService, StudentService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.UseRouting();
        // app.UseAuthorization();

        app.MapGet("/test", () => "API is working!");
        
        app.MapControllers();

        app.Run();
    }
}