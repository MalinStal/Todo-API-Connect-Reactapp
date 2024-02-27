using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace Todo_api;
public class TodoDbContext : IdentityDbContext<User>{
public DbSet<Todo> Todos {get; set;}

public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {

}
}