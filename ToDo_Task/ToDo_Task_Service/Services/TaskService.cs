using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
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


    public async Task<List<TaskListDto>> GetAllTasks()
    {
        var tasksList = await _unitOfWork.TaskRepository.All();
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
        var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Identities.First().Name);
        task.UserId = userId;
        var user =await _unitOfWork.UserRepository.GetUserById(userId);
        task.User = user;
        await _unitOfWork.TaskRepository.Add(task);
        return task.Id;
    }

    public async Task<bool> UpdateTask(TaskSaveDto taskSaveDto)
    {
        var task = _mapper.Map<Tasks>(taskSaveDto);
        return await _unitOfWork.TaskRepository.Update(task);
    }

    public async Task<bool> DoneTask(int taskId)
        => await _unitOfWork.TaskRepository.DoneTask(taskId);


    public async Task<bool> DeleteTask(int taskId)
        => await _unitOfWork.TaskRepository.Delete(taskId);
}