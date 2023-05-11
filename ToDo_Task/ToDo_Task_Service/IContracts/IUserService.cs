using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Service.DataTransferObjects.Users;

namespace ToDo_Task_Service.IContracts;

public interface IUserService
{
   public Task<bool> Register(UserSaveDto userSaveDto);
   public Task<string> Login(UserSaveDto userSaveDto);
   public Task<User> GetById(int userId);
}