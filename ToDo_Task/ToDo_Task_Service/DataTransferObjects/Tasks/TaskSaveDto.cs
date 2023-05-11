namespace ToDo_Task_Service.DataTransferObjects;

public record TaskSaveDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    //  public bool IsDone { get; set; }
}