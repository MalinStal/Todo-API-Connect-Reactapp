namespace Todo_api;

public class TodoService{

//public List<Todo> todos = new List<Todo>();

private TodoDbContext context;

public TodoService(TodoDbContext context){
    this.context = context;
}
   public Todo? CreateTodo(string title, string description)
   {

    if(string.IsNullOrWhiteSpace(title))
    {
        throw new ArgumentException("you need to enter a title");
    }
     if(string.IsNullOrWhiteSpace(description))
     {
        throw new ArgumentException("you need to enter a description");
    }
       
        Todo? todo = new Todo(title, description);
        context.Todos.Add(todo);
        context.SaveChanges();
        return todo;
    }

    public Todo? RemoveTodo(int id ){
       Todo? todo = context.Todos.Find(id);
       if(todo == null ){
        return null;
       }
       context.Todos.Remove(todo);
       context.SaveChanges();

       return todo;
    }

    public List<Todo> GetAllTodos(){
        return context.Todos.ToList();
    }

    public Todo? UpdateTodo(int id, bool completed){
           Todo? todo = context.Todos.Find(id);
        if (todo == null)
        {
            return null;
        }

        todo.Completed = completed;
        context.SaveChanges();

        return todo;
    }

 
   
}