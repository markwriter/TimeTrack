using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrack.Models;

namespace TimeTrack.Services
{
    public class StatusEntryService
    {
        private readonly TimeTrackContext _context;

        public StatusEntryService(TimeTrackContext context)
        {
            DataGenerator.Initialize(context);
            _context = context;
        }

        public async Task<IEnumerable<StatusEntry>> GetStatusEntries()
        {
            return await _context.StatusEntries.ToListAsync();
        }

        public async Task<StatusEntry> GetStatusEntry(long id)
        {
            return await _context.StatusEntries.FindAsync(id);
        }

        public bool StatusEntryExists(long id)
        {
            return _context.StatusEntries.Any(e => e.Id == id);
        }

        internal async Task<bool> ModifyStatusEntry(StatusEntry StatusEntry)
        {
            _context.Entry(StatusEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEntryExists(StatusEntry.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        internal async Task AddStatusEntry(StatusEntry StatusEntry)
        {
            _context.StatusEntries.Add(StatusEntry);
            await _context.SaveChangesAsync();
        }

        internal async Task<StatusEntry> RemoveStatusEntry(long id)
        {
            StatusEntry StatusEntry = await GetStatusEntry(id);

            //if (StatusEntry == null)
            //{
            //    return NotFound();
            //}

            _context.StatusEntries.Remove(StatusEntry);
            await _context.SaveChangesAsync();
            return await _context.StatusEntries.FindAsync(id);
        }
    }
}
