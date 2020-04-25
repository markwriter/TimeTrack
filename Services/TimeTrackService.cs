using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrack.Models;

namespace TimeTrack.Services
{
    public class TimeTrackService
    {
        private readonly TimeTrackContext _context;

        public TimeTrackService(TimeTrackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(long id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public bool EmployeeExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        internal async Task<bool> ModifyEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        internal async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        internal async Task<Employee> RemoveEmployee(long id)
        {
            Employee employee = await GetEmployee(id);

            //if (employee == null)
            //{
            //    return NotFound();
            //}

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return await _context.Employees.FindAsync(id);
        }
    }
}
