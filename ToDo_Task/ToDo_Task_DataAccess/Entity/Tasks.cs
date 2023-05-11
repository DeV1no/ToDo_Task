namespace ToDo_Task_DataAccess.Entity;

public class Tasks
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    // Relations 
    public User User { get; set; } = new User();
    public int UserId { get; set; }
}