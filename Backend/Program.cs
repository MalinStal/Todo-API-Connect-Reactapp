using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace Todo_api;

public class Program
{
    public static void Main(string[] args)
    {
           var builder = WebApplication.CreateBuilder(args);
        //registrera med dependensie ingetions
        builder.Services.AddDbContext<TodoDbContext>(
            options =>
                options.UseNpgsql(
                    "Host=localhost;Database=p-todo-app;Username=postgres;Password=todo"
                )
        );
        builder.Services.AddControllers();
        builder.Services.AddScoped<TodoService, TodoService>();     
       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
       
       builder.Services.AddCors(options=>{
        options.AddPolicy("test",policy=>{
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
       });

       var app = builder.Build();

          // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors();
    
        app.MapControllers();
        app.UseHttpsRedirection();

        app.Run();
    }
}
