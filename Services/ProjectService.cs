using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrack.Models;

namespace TimeTrack.Services
{
    public class ProjectService
    {
        private readonly TimeTrackContext _context;

        public ProjectService(TimeTrackContext context)
        {
            DataGenerator.Initialize(context);
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProject(long id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public bool ProjectExists(long id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

        internal async Task<bool> ModifyProject(Project Project)
        {
            _context.Entry(Project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        internal async Task AddProject(Project Project)
        {
            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();
        }

        internal async Task<Project> RemoveProject(long id)
        {
            Project Project = await GetProject(id);

            //if (Project == null)
            //{
            //    return NotFound();
            //}

            _context.Projects.Remove(Project);
            await _context.SaveChangesAsync();
            return await _context.Projects.FindAsync(id);
        }
    }
}
