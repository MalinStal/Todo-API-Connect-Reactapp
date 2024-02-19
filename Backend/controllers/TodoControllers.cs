using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace Todo_api;

public class TodoDto{
   
    public string Title {get; set;} = ""; 
    public string Description {get; set;} = ""; 



    public TodoDto(string title, string description){
        this.Title = title;
        this.Description =description;
    }
}

[ApiController]
[Route("todo")]
public class TodoControllers : ControllerBase{

TodoService todoService;

public TodoControllers(TodoService TodoService){
    this.todoService = TodoService;
}

  [HttpPost("add")]
  [EnableCors("test")]
    public IActionResult CreateTodo([FromBody] TodoDto dto)
    {
        try
        {
            Todo? todo = todoService.CreateTodo(dto.Title, dto.Description);
            return Ok(todo);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }



[HttpGet("get")]
 [EnableCors("test")]
public List<Todo> GetTodos(){
    return todoService.GetAllTodos();
}


[HttpPut("update/{id}")]
 [EnableCors]
public IActionResult UpdateTodos(int id, [FromQuery] bool completed){
   Todo? todo  =  todoService.UpdateTodo(id, completed);
   if(todo == null){
    return NotFound();
   }
   return Ok(todo);
}

[HttpDelete("delete/{id}")]
 [EnableCors]
public IActionResult RemoveTodo(int id){
    Todo? todo= todoService.RemoveTodo(id);
    if(todo == null){
        return NotFound();
    }
    return Ok(todo);
}

}