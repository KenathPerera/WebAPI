using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailController : ControllerBase
    {
        private readonly TaskDetailsContext _context;

        public TaskDetailController(TaskDetailsContext context)
        {
            _context = context;
        }

        // GET: api/TaskDetail
        [HttpGet]
        public IEnumerable<TaskDetail> GetTaskDetails()
        {
            return _context.TaskDetails;
        }

        // GET: api/TaskDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskDetail = await _context.TaskDetails.FindAsync(id);

            if (taskDetail == null)
            {
                return NotFound();
            }

            return Ok(taskDetail);
        }

        // PUT: api/TaskDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDetail([FromRoute] int id, [FromBody] TaskDetail taskDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskDetail.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(taskDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskDetail
        [HttpPost]
        public async Task<IActionResult> PostTaskDetail([FromBody] TaskDetail taskDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TaskDetails.Add(taskDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskDetail", new { id = taskDetail.TaskId }, taskDetail);
        }

        // DELETE: api/TaskDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskDetail = await _context.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            _context.TaskDetails.Remove(taskDetail);
            await _context.SaveChangesAsync();

            return Ok(taskDetail);
        }

        private bool TaskDetailExists(int id)
        {
            return _context.TaskDetails.Any(e => e.TaskId == id);
        }
    }
}