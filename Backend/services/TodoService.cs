namespace Todo_api;

public class TodoService{

//public List<Todo> todos = new List<Todo>();

private TodoDbContext context;

public TodoService(TodoDbContext context){
    this.context = context;
}
   public Todo? CreateTodo(string title, string description, string id)
   {

    if(string.IsNullOrWhiteSpace(title))
    {
        throw new ArgumentException("you need to enter a title");
    }
     if(string.IsNullOrWhiteSpace(description))
     {
        throw new ArgumentException("you need to enter a description");
    }
       User? user = context.Users.Find(id);
       if(user == null){
        throw new ArgumentException("this user is cant be find");
       }
        Todo? todo = new Todo(title, description, user);
        context.Todos.Add(todo);
        user.todos.Add(todo);
        context.SaveChanges();
        return todo;
        
    }

    public Todo? RemoveTodo(int id, string userId ){

        User? user = context.Users.Find(userId);
       if(user == null){
        throw new ArgumentException("this user is cant be find");
       }

       List<Todo> todos = context.Todos.Where(todo => todo.User.Id == user.Id && todo.Id == id).ToList();
       if(todos.Count == 0){
            return null;
       }
       Todo? todo = todos[0];
       context.Todos.Remove(todo);
       context.SaveChanges();

       return todo;
    }

    public List<Todo> GetAllTodos(string userId){
        User? user = context.Users.Find(userId);
        if(user == null){
       return new List<Todo>();
       }

        return context.Todos.Where(todo => todo.User.Id == userId).ToList();
    }

    public Todo? UpdateTodo(int id, bool completed, string userId){
      User? user = context.Users.Find(userId);
       if(user == null){
        throw new ArgumentException("this user is cant be find");
       }

       List<Todo> todos = context.Todos.Where(todo => todo.User.Id == user.Id && todo.Id == id).ToList();
       if(todos.Count == 0){
            return null;
       }
       Todo? todo = todos[0];

        todo.Completed = completed;
        context.SaveChanges();

        return todo;
    }

 
   
}