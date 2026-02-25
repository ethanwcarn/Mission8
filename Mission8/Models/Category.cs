// =============================================================================
// JARED - Assignment #1: Models / Database / Setup
// Purpose: Category model for dropdown (Home, School, Work, Church).
//          Break out into separate table per assignment requirements.
// =============================================================================

using System.ComponentModel.DataAnnotations;

namespace Mission8.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
