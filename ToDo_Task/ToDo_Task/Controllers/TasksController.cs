using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo_Task_Service.DataTransferObjects;
using ToDo_Task_Service.IContracts;

namespace ToDo_Task.Controllers;
[ApiController]
[Route("[controller]")]
public class TasksController:ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllTasks() 
        => Ok(await _taskService.GetAllTasks());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
        => Ok(await _taskService.GetTaskById(id));
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] TaskSaveDto model)
        => Ok(await _taskService.AddTask(model));
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskSaveDto model)
        => Ok(await _taskService.UpdateTask(model));
    [HttpPut("DoneTask/{id:int}")]
    public async Task<IActionResult> DoneTask(int id)
        => Ok(await _taskService.DoneTask(id));
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
        => Ok(await _taskService.DeleteTask(id));
}