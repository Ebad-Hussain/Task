using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestTask.Core.Interfaces;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("get-task", Name = "GetTaskInformation")]
        public async Task<ActionResult> GetTaskInformation([FromQuery][Required] long employeeId, [FromQuery][Required] DateTime fromDate, [FromQuery][Required] DateTime toDate)
        {
            var tasks = await _taskService.GetTaskInformation(employeeId, fromDate, toDate);
            if (tasks.Count > 0)
                return Ok(tasks);
            else
                return NotFound("No data found");
        }
    }
}
