namespace Todo_api;

public class TodoService{

public List<Todo> todos = new List<Todo>();
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
        todos.Add(todo);
        return todo;
    }

    public Todo? RemoveTodo(int id ){
        for(int i = 0; i < todos.Count; i++){
        if (todos[i].Id == id)
            {
                Todo todo = todos[i];
                todos.RemoveAt(i);
                return todo;
            }
        } 
        return null;
    }

    public List<Todo> GetAllTodos(){
        return todos;
    }

    public Todo? UpdateTodo(int id, bool completed){
       for (int i = 0; i < todos.Count; i++)
        {
            if (todos[i].Id == id)
            {
                Todo todo = todos[i];
                todo.Completed = completed;
                return todo;
            }
        }

        return null;
    }

 
   
}