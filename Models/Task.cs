using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateOnly? Deadline { get; set; }
    }
}
