using System.Linq.Expressions;
using ToDo_Task_DataAccess.Entity;

namespace ToDo_Task_Repository.IRepositories;

public interface ITaskRepository :IGenericRepository<Tasks>
{
    public Task<bool> DoneTask(int taskId);
    public Task<List<Tasks>> All(string? userName);
    public Task<Tasks?> GetById(int id, int? userCreatorId);
    public Task<bool> IsTaskExit(Expression<Func<Tasks, bool>> condition);
}