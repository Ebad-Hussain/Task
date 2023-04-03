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
            List<TaskReturableDto> tasksList = new ();

            var tasks = await _dbContext.TimeEntries
                .Where(te => te.EmployeeId == employeeId && te.Date >= fromDate && te.Date <= toDate)
                .GroupBy(te => te.TaskId).Select(g => new {
                    Description = g.FirstOrDefault().Task.Description,
                    EstimatedHours = g.FirstOrDefault().Task.EstimatedHours,
                    HoursSpent = g.FirstOrDefault().HoursSpent
                })
                .AsNoTracking().ToListAsync();

            foreach (var task in tasks)
            {
                tasksList.Add(new TaskReturableDto
                {
                    Description = task.Description,
                    EstimatedHours = task.EstimatedHours,
                    HoursSpent = task.HoursSpent
                });
            }
            return tasksList;
        }
    }
}
