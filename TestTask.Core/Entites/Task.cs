using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Entites
{
    public class Task
    {
        public long TaskId { get; set; }
        public string Description { get; set; }
        public string EstimatedHours { get; set; }
        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
