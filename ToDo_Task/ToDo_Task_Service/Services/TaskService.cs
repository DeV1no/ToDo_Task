using AutoMapper;
using Microsoft.AspNetCore.Http;
using ToDo_Task_DataAccess;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Repository.IConfiguration;
using ToDo_Task_Service.DataTransferObjects;
using ToDo_Task_Service.IContracts;

namespace ToDo_Task_Service.Services;

public class TaskService : ITaskService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TaskService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<List<TaskListDto>> GetAllTasks(string? userName)
    {
        var tasksList = await _unitOfWork.TaskRepository.All(userName);
        return _mapper.Map<List<Tasks>, List<TaskListDto>>(tasksList);
    }

    public async Task<TaskSaveDto> GetTaskById(int taskId)
    {
        var task = await _unitOfWork.TaskRepository.GetById(taskId);
        return _mapper.Map<TaskSaveDto>(task);
    }



    public async Task<int> AddTask(TaskSaveDto taskSaveDto)
    {

        var task = _mapper.Map<Tasks>(taskSaveDto);
        var userId = GetTaskUserCreatorId();
        task.UserId = userId;
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
        task.User = user;
        await _unitOfWork.TaskRepository.Add(task);
        return task.Id;
    }



    public async Task<bool> UpdateTask(TaskSaveDto taskSaveDto)
    {
        await IsTaskExit(taskSaveDto.Id);
        var task = _mapper.Map<Tasks>(taskSaveDto);
        return await _unitOfWork.TaskRepository.Update(task);
    }

    

    public async Task<bool> DoneTask(int taskId)
    {
        await IsTaskExit(taskId);
        return  await _unitOfWork.TaskRepository.DoneTask(taskId);
    }



    public async Task<bool> DeleteTask(int taskId)
    {
        await IsTaskExit(taskId);
        return await _unitOfWork.TaskRepository.Delete(taskId);
    }
       


    private int GetTaskUserCreatorId()
    => Convert.ToInt32(_httpContextAccessor.HttpContext!.User.Identities.First().Name);
    private async Task IsTaskExit( int taskId)
    {
        var userId = GetTaskUserCreatorId();
        var isTaskExit = await _unitOfWork.TaskRepository.IsTaskExit(x => x.UserId == userId&& x.Id==taskId);
        if (!isTaskExit)  throw new Exception("TaskId Not Found");
    }
}