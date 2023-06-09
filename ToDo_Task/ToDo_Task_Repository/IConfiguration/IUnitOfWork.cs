﻿using ToDo_Task_Repository.IRepositories;

namespace ToDo_Task_Repository.IConfiguration;

public interface IUnitOfWork
{ 
    ITaskRepository TaskRepository { get; }
    IUserRepository UserRepository { get; }
    Task CompleteAsync();
}