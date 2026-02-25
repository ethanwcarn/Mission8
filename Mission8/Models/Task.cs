// =============================================================================
// JARED - Assignment #1: Models / Database / Setup
// Purpose: Task model with Task (required), Due Date, Quadrant (required),
//          Category (FK to Category table), Completed (True/False)
// =============================================================================

using System.ComponentModel.DataAnnotations;

namespace Mission8.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(200)]
        public string TaskName { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required.")]
        [Range(1, 4, ErrorMessage = "Quadrant must be between 1 and 4.")]
        public int Quadrant { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool Completed { get; set; }
    }
}
