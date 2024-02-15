using Microsoft.AspNetCore.Mvc;
namespace Todo_api;

public class Program
{
    public static void Main(string[] args)
    {
           var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddSingleton<TodoService, TodoService>();     
       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
       
       builder.Services.AddCors();
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
