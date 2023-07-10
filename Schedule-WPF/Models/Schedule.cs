using System;

namespace Schedule_WPF.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Pending { get; set; }
        public bool Jeopardy { get; set; }
        public bool Completed { get; set; }
    }
}
