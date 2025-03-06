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
            var response = tasks.Select(response => new TaskDto
            {
                Title = response.Title,
                Description = response.Description,
                IsCompleted = response.IsCompleted,
                CreatedAt = response.CreatedAt,
                Deadline = response.Deadline
            }).ToList();

            return Ok(response);
        }
    }
}
