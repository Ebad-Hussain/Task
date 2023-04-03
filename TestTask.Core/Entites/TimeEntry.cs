using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Entites
{
    public class TimeEntry
    {
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long  TaskId { get; set; }
        public Task Task { get; set; }
        public string HoursSpent { get; set; }
        public DateTime Date { get; set; }
    }
}
