using AutoMapper;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Service.DataTransferObjects;

namespace ToDo_Task_Service.Mappings;

public class TaskMappings : Profile
{
    public TaskMappings()
    {
        CreateMap<Tasks, TaskSaveDto>().ReverseMap();
        CreateMap<Tasks, TaskListDto>();

    }
}