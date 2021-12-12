using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication13.Models
{
    public class Schedule
    {
        public string Id { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string dayOfWeek { get; set; }
        public string quardId { get; set; }
    }
}
