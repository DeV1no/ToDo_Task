namespace ToDo_Task_Service.DataTransferObjects.Users;

public record UserSaveDto
{
    public string UserName { get; set; } = string.Empty;
    public string PassWord { get; set; } = string.Empty;
}