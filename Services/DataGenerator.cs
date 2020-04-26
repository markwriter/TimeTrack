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
