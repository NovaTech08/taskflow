using Xunit;
using TaskFlow.Services;
using TaskFlow.Models;
using System.Collections.Generic;

namespace TaskFlow.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public void GetAllTasks_ShouldReturnList_NotNull()
        {
            var service = new TaskService();

            var tasks = service.GetAllTasks();

            Assert.NotNull(tasks);
        }

        [Fact]
        public void GetAllTasks_WhenServiceStarts_ShouldBeEmpty()
        {
            var service = new TaskService();

            var tasks = service.GetAllTasks();

            Assert.Empty(tasks);
        }

        [Fact]
        public void GetAllTasks_MultipleCalls_ReturnSameListInstance()
        {
            var service = new TaskService();

            var tasks1 = service.GetAllTasks();
            var tasks2 = service.GetAllTasks();

            Assert.Equal(tasks1, tasks2);
        }

        [Fact]
        public void GetAllTasks_ShouldReturnListOfTaskItem()
        {
            var service = new TaskService();

            var tasks = service.GetAllTasks();

            Assert.IsType<List<TaskItem>>(tasks);
        }
    }
}