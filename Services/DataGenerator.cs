using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrack.Models;

namespace TimeTrack.Services
{
    public class DataGenerator
    {
        public static void Initialize(TimeTrackContext context)
        {
            AddEmployees(context);
            AddProjects(context);
            AddStatusEntries(context);
        }

        private static void AddStatusEntries(TimeTrackContext timeTrackContext)
        {
            if (timeTrackContext.StatusEntries.Any())
            {
                return;
            }

            timeTrackContext.StatusEntries.AddRange(
                    new StatusEntry
                    {
                        Id = 1,
                        EmployeeId = 1,
                        ProjectId = 1,
                        Date = DateTime.Parse("04/27/2020"),
                        Hours = 4,
                        Ticket = "Jira 1",
                        Issue = "Misspelling on help button on quote page",
                        Description = "Fixed misspelling after intensive research in dictionaries, encyclopedias and wikipedia"
                    },
                    new StatusEntry
                    {
                        Id = 2,
                        EmployeeId = 1,
                        ProjectId = 1,
                        Date = DateTime.Parse("04/27/2020"),
                        Hours = 4,
                        Ticket = "Jira 2",
                        Issue = "Links not opening properly when inserted into tables",
                        Description = "Created new schema for links and put that in.  Had to test multiple ways in order to validate the fix.  Also will need to put in bookmark links."
                    },
                    new StatusEntry
                    {
                        Id = 3,
                        EmployeeId = 2,
                        ProjectId = 3,
                        Date = DateTime.Parse("04/27/2020"),
                        Hours = 4,
                        Ticket = "Jira 4",
                        Issue = "Horizontal rule not displaying when more than 10 lines in table",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    }
                );
            timeTrackContext.SaveChanges();
        }
        private static void AddProjects(TimeTrackContext context)
        {
            if (context.Projects.Any())
            {
                return;
            }

            context.Projects.AddRange(
                new Project
                {
                    Id = 1,
                    Name = "UW"
                },
                new Project
                {
                    Id = 2,
                    Name = "PI"
                },
                new Project
                {
                    Id = 3,
                    Name = "Duck Creek"
                },
                new Project
                {
                    Id = 4,
                    Name = "Support Tickets"
                },
                new Project
                {
                    Id = 5,
                    Name = "SIB Printing"
                },
                new Project
                {
                    Id = 6,
                    Name = "ACES Rewrite"
                });

            context.SaveChanges();
        }
        private static void AddEmployees(TimeTrackContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            context.Employees.AddRange(
                new Employee
                {
                    Id = 1,
                    FirstName = "Bart",
                    LastName = "Simpson"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Indiana",
                    LastName = "Jones"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Luke",
                    LastName = "Trashtalker"
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Jeff",
                    LastName = "Smedley"
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Gar",
                    LastName = "Junklin"
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Zeke",
                    LastName = "Loudermouth"
                });

            context.SaveChanges();
        }
    }
}
