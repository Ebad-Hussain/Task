using TestTask.Core.DTOs;

namespace TestTask.Core.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskReturableDto>> GetTaskInformation(long employeeId, DateTime fromDate, DateTime toDate);
    }
}
