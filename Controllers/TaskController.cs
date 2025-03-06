using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskManagementContext _context;

        public TaskController(TaskManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks() 
        {
            var tasks = await _context.Tasks.ToListAsync();
            var responses = tasks.Adapt<List<TaskDto>>();
            return Ok(responses);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTaskById(int Id)
        {
            var task = await _context.Tasks.FindAsync(Id);

            if (task == null)
                return NotFound();

            var response = task.Adapt<TaskDto>();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskDto taskDto)
        {
            var task = taskDto.Adapt<Models.Task>();
            task.IsCompleted = false; // Initialize the situation of task.
            task.CreatedAt = DateTime.UtcNow; // Set the CreatedAt property.

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskById), new {Id = task.Id}, task.Adapt<TaskDto>());

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTask(int Id, TaskDto taskDto)
        {
            var task = await _context.Tasks.FindAsync(Id);
            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.IsCompleted = taskDto.IsCompleted;
            task.Deadline = taskDto.Deadline;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTask(int Id)
        {
            var task = _context.Tasks.Find(Id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
