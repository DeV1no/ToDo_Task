
using Microsoft.AspNetCore.Identity;

namespace ToDo_Task_DataAccess.Entity;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PassWord { get; set; } = string.Empty;
    // Relations
    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}