using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
namespace Todo_api;

public class Program
{
    public static void Main(string[] args)
    {
           var builder = WebApplication.CreateBuilder(args);
//addpolicy bestämmer att det som har dessa policys måste vara inloggade och autorize för att kunna ex skapa eller ta bort todo
           builder.Services.AddAuthorization(options => {
                options.AddPolicy("create-todo", policy => {
                    policy.RequireAuthenticatedUser();
                });
                 options.AddPolicy("delete-todo", policy => {
                    policy.RequireAuthenticatedUser();
                });
                 options.AddPolicy("update-todo", policy => {
                    policy.RequireAuthenticatedUser();
                });
                 options.AddPolicy("get-todos", policy => {
                    policy.RequireAuthenticatedUser();
                });
           });
        //registrera med dependensie ingetions
        builder.Services.AddDbContext<TodoDbContext>(
            options =>
                options.UseNpgsql(
                    "Host=localhost;Database=p-todo-app;Username=postgres;Password=todo"
                )
        );
        //skapar tokens automatiskt 
        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<TodoDbContext>()
            .AddApiEndpoints();
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
        app.MapIdentityApi<User>();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.Run();
    }
}
