using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.DTOs
{
    public class TaskReturableDto
    {
        public string? Description { get; set; }
        public string? EstimatedHours { get; set; }
        public string? HoursSpent { get; set; }
    }
}
