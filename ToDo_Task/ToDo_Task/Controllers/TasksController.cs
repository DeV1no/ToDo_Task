﻿using Microsoft.AspNetCore.Mvc;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
        => Ok(await _taskService.GetTaskById(id));

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] TaskSaveDto model)
        => Ok(await _taskService.AddTask(model));

    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] TaskSaveDto model)
        => Ok(await _taskService.UpdateTask(model));
    [HttpPut("DoneTask/{id:int}")]
    public async Task<IActionResult> DoneTask(int id)
        => Ok(await _taskService.DoneTask(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
        => Ok(await _taskService.DeleteTask(id));
}