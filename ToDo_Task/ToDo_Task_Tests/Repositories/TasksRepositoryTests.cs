using Microsoft.EntityFrameworkCore;
using ToDo_Task_DataAccess;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Repository.Repositories;

namespace ToDo_Task_Tests.Repositories
{
    [TestClass]
    public class TasksRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public TasksRepository()
        {
            var dbName = $"ToDoTasks_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [TestMethod]
        public async Task Get_TasksAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var taskList = await repository.All();

            // Assert
            Assert.AreEqual(3, taskList.Count);
        }

        [TestMethod]
        public async Task Done_TasksAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();
        
            // Act
            var taskStatus = await repository.DoneTask(1);

            // Assert
            Assert.AreEqual(true, taskStatus);
        }
        [TestMethod]
        public async Task Add_Task_Async_Success_Test()
        {
            var repository = await CreateRepositoryAsync();
            var task = new Tasks()
            {
                Title = "Title",
                Description = "Description",
                CreatedDate = DateTime.Now,
                IsDone = false,
                UserId = 1
            };;
        
            // Act
            var newTask = await repository.Add(task);
        
            // Assert
            Assert.AreEqual(4, newTask.Id);
        }
        [TestMethod]
        public async Task Delete_Task_Async_Success_Test()
        {
            var repository = await CreateRepositoryAsync();
            
            // Act
            var newTask = await repository.Delete(1);
        
            // Assert
            Assert.AreEqual(true, newTask);
        }

        private async Task<TaskRepository> CreateRepositoryAsync()
        {
            var context = new ApplicationDbContext(_dbContextOptions);
            await PopulateDataAsync(context);
            return new TaskRepository(context);
        }

        private async Task PopulateDataAsync(ApplicationDbContext context)
        {
            var index = 1;
            while (index <= 3)
            {
                var task = new Tasks()
                {
                    Title = $"Title_{index}",
                    Description = $"Description_{index}",
                    CreatedDate = DateTime.Now,
                    IsDone = false,
                    UserId = 1
                };

                index++;
                await context.Tasks.AddAsync(task);
            }

            await context.SaveChangesAsync();
        }
    }
}