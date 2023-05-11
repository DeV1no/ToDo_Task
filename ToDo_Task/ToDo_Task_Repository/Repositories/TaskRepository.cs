using Microsoft.EntityFrameworkCore;
using ToDo_Task_DataAccess;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Repository.IRepositories;

namespace ToDo_Task_Repository.Repositories;

public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext context)
        : base(context)
    {

    }



    public async Task<List<Tasks>> All(string? userName)
        => await _dbSet.Include(x=>x.User)
            .Where(x=>userName == null || x.User.UserName==userName)
            .ToListAsync();

   
    public override async Task<Tasks?> GetById(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException();
    }

    public async Task<bool> DoneTask(int taskId)
    {
        var task = await _dbSet.SingleOrDefaultAsync(x => x.Id == taskId);
        if (task is null) throw new NotFoundException();
        task.IsDone = true;
        _dbSet.Update(task);
        return task.IsDone;

    }
}
public class NotFoundException : Exception
{
}