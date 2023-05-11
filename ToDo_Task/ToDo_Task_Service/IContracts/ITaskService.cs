using ToDo_Task_Service.DataTransferObjects;

namespace ToDo_Task_Service.IContracts;

public interface ITaskService
{
    public Task<List<TaskListDto>> GetAllTasks(string? userCreator);
    public Task<TaskSaveDto> GetTaskById(int taskId);
    public Task<int> AddTask(TaskSaveDto  taskSaveDto);
    public Task<bool> UpdateTask(TaskSaveDto taskSaveDto);
    public Task<bool> DoneTask(int taskId);
    public Task<bool> DeleteTask(int  taskId);
}