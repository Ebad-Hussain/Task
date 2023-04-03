using Microsoft.EntityFrameworkCore;
using TestTask.Core.DTOs;
using TestTask.Core.Interfaces;
using TestTask.Infrastructure.Context;

namespace TestTask.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly TestTaskDbContext _dbContext;

        public TaskService(TestTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async System.Threading.Tasks.Task<List<TaskReturableDto>> GetTaskInformation(long employeeId, DateTime fromDate, DateTime toDate)
        {
            List<TaskReturableDto> taskList = new ();
            var result = await _dbContext.Tasks
                .Select(t => new {
                    t.Description,
                    t.EstimatedHours,
                    HoursSpent = _dbContext.TimeEntries
                    .Where(te => te.EmployeeId == employeeId && te.TaskId == t.TaskId && te.Date >= fromDate && te.Date <= toDate)
                    .Select(te => te.HoursSpent).FirstOrDefault()
                }).ToListAsync();
            foreach(var task in result)
            {
                taskList.Add(new TaskReturableDto
                {
                    Description = task.Description,
                    EstimatedHours = task.EstimatedHours,
                    HoursSpent = task.HoursSpent
                });
            }
            return taskList;
        }
    }
}
