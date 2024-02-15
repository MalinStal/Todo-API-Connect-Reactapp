
namespace Todo_api;

public class Todo
{
    private static int ID_COUNTER = 0;

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
        this.CreationDate = DateTime.Now;
        this.Id = ID_COUNTER++;
    }

}