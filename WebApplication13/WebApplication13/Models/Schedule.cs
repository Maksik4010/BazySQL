using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.models
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
