using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrack.Models
{
    public class TimeTrackContext : DbContext
    {
        public TimeTrackContext(DbContextOptions<TimeTrackContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
