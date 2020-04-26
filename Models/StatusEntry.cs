using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrack.Models
{
    public class StatusEntry
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long EmployeeId { get; set; }
        public string Ticket { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Hours { get; set; }
    }
}
