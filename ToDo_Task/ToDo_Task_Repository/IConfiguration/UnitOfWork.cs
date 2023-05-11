using ToDo_Task_DataAccess;
using ToDo_Task_Repository.IRepositories;
using ToDo_Task_Repository.Repositories;

namespace ToDo_Task_Repository.IConfiguration;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    public ITaskRepository TaskRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        TaskRepository = new TaskRepository(_context);
        UserRepository = new UserRepository(_context);

    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}