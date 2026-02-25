// =============================================================================
// JARED - Assignment #1: Models / Database / Setup
// Purpose: Repository interface for Category operations (populate dropdown).
// =============================================================================

using Mission8.Models;

namespace Mission8.Data
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        IEnumerable<Category> GetAllCategories();
    }
}
