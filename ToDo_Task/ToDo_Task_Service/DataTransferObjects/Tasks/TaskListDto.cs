namespace ToDo_Task_Service.DataTransferObjects;

public record TaskListDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public string UserCreator { get; set; }= string.Empty;
}