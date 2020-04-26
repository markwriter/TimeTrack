using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrack.Models;
using TimeTrack.Services;

namespace TimeTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusEntryController : ControllerBase
    {
        private readonly StatusEntryService _statusEntryService;

        public StatusEntryController(StatusEntryService projectService)
        {
            _statusEntryService = projectService;
        }

        // GET: api/StatusEntrys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusEntry>>> GetStatusEntrys()
        {
            return Ok(await _statusEntryService.GetStatusEntries());
        }

        // GET: api/StatusEntrys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusEntry>> GetStatusEntry(long id)
        {
            var project = await _statusEntryService.GetStatusEntry(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/StatusEntrys/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusEntry(long id, StatusEntry project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            return await _statusEntryService.ModifyStatusEntry(project) ?
                (IActionResult)base.NoContent() :
                base.NotFound();
        }

        // POST: api/StatusEntrys
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StatusEntry>> PostStatusEntry(StatusEntry project)
        {
            await _statusEntryService.AddStatusEntry(project);
            return CreatedAtAction(nameof(GetStatusEntry), new { id = project.Id }, project);
        }

        // DELETE: api/StatusEntrys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusEntry>> DeleteStatusEntry(long id)
        {
            return await _statusEntryService.RemoveStatusEntry(id);
        }


    }
}
