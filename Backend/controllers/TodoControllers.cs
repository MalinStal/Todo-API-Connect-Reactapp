using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Todo_api;

[ApiController]
[Route("todo")]
public class TodoControllers : ControllerBase
{
    TodoService todoService;

    public TodoControllers(TodoService TodoService)
    {
        this.todoService = TodoService;
    }

    [HttpPost("add")]
    [EnableCors("test")]
    [Authorize("create-todo")]
    public IActionResult CreateTodo([FromBody] CreateTodoDto dto)
    {
        try
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                throw new Exception("user is null");
            }
            Todo? todo = todoService.CreateTodo(dto.Title, dto.Description, id);
            if (todo == null)
            {
                throw new Exception("output is null");
            }
            TodoDto? output = new TodoDto(todo);

            return Ok(output);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }

    [HttpGet("get")]
    [EnableCors("test")]
    [Authorize("get-todos")]
    public List<TodoDto> GetTodos()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId != null){
             return todoService.GetAllTodos(userId).Select(todo => new TodoDto(todo)).ToList();
        }
        return new List<TodoDto>();
    }

    [HttpPut("update/{id}")]
    [EnableCors]
    [Authorize("update-todo")]
    public IActionResult UpdateTodos(int id, [FromQuery] bool completed)
    {
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return NotFound();
        }

        Todo? todo = todoService.UpdateTodo(id, completed, userId);
        if (todo == null)
        {
            return NotFound();
        }

        TodoDto output = new TodoDto(todo);
        return Ok(output);
    }

    [HttpDelete("delete/{id}")]
    [EnableCors]
    [Authorize("delete-todo")]
    public IActionResult RemoveTodo(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            throw new Exception("user is null");
        }
        Todo? todo = todoService.RemoveTodo(id, userId);
        if (todo == null)
        {
            return NotFound();
        }
        TodoDto output = new TodoDto(todo);
        return Ok(output);
    }
}
