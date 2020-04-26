using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrack.Models;

namespace TimeTrack.Models
{
    public class TimeTrackContext : DbContext
    {
        public TimeTrackContext(DbContextOptions<TimeTrackContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<StatusEntry> StatusEntries{get; set;}
    }
}
