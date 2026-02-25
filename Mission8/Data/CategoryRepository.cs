// =============================================================================
// JARED - Assignment #1: Models / Database / Setup
// Purpose: Repository implementation for Category operations.
// =============================================================================

using Mission8.Models;

namespace Mission8.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Mission8Context _context;

        public CategoryRepository(Mission8Context context)
        {
            _context = context;
        }

        public IQueryable<Category> Categories => _context.Categories.OrderBy(c => c.CategoryName);

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryName).ToList();
        }
    }
}
