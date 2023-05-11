using ToDo_Task_DataAccess.Entity;

namespace ToDo_Task_Repository.IRepositories;

public interface IUserRepository
{
    public Task<bool> Register(User user);
    public Task<User> Login(User user);
    public Task<User> GetUserById(int userId);
}