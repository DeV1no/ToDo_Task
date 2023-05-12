using Microsoft.EntityFrameworkCore;
using ToDo_Task_DataAccess;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Repository.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ToDo_Task_Test.Repositories
{

    public class UnitTest1
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public UnitTest1()
        {
            var dbName = $"ToDoTasks_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task Get_TasksAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var taskList = await repository.All();

            // Assert
            Assert.Equal(3, taskList.Count);
        }

        // [Fact]
        // public async Task Done_TasksAsync_Success_Test()
        // {
        //     var repository = await CreateRepositoryAsync();
        //
        //     // Act
        //     var taskList = await repository.DoneTask(1);
        //
        //     // Assert
        //     Assert.IsTrue(ValidationUI.InList(1, typeof(TestEnum));
        // }


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
