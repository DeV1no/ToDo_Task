using ToDo_Task_DataAccess.Entity;

namespace ToDo_Task_Repository.IRepositories;

public interface ITaskRepository :IGenericRepository<Tasks>
{
    public Task<bool> DoneTask(int taskId);
}