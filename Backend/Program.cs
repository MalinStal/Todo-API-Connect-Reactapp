using Microsoft.AspNetCore.Mvc;
namespace Todo_api;

public class Program
{
    public static void Main(string[] args)
    {
           var builder = WebApplication.CreateBuilder(args);

       builder.Services.AddControllers();
        builder.Services.AddSingleton<TodoService, TodoService>();     
        var app = builder.Build();

        app.MapControllers();
        app.UseHttpsRedirection();

        app.Run();
    }
}
