using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace Todo_api;

public class Todo
{
    //SQL hanterar id cont själv denna beöhvs ej
    // private static int ID_COUNTER = 0;

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }

    public Todo(string title, string description)
    {
        this.Title = title;
        this.Description = description;
        this.Completed = false;
        this.CreationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
       
    }

}

public class TodoDbContext : DbContext{
public DbSet<Todo> Todos {get; set;}

public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {

}
}