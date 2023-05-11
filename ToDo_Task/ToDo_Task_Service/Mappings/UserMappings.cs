using AutoMapper;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Service.DataTransferObjects.Users;

namespace ToDo_Task_Service.Mappings;

public class UserMappings:Profile
{
    public UserMappings()
    {
        CreateMap<User, UserSaveDto>().ReverseMap();

    }
}