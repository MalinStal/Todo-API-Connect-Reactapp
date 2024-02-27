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
   public User User {set; get;}
    public Todo(){}
    public Todo(string title, string description, User user)
    {
        this.Title = title;
        this.Description = description;
        this.Completed = false;
        this.CreationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        this.User = user;
     
       
    }

}

public class TodoDto{
      public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
   
   public TodoDto(){}
    public TodoDto(Todo todo)
    {
        this.Id = todo.Id;
        this.Title = todo.Title;
        this.Description = todo.Description;
        this.Completed = todo.Completed;
   
     
       
    }
}
public class CreateTodoDto{
   
    public string Title {get; set;} = ""; 
    public string Description {get; set;} = ""; 



    public CreateTodoDto(string title, string description){
        this.Title = title;
        this.Description =description;
    }
}
