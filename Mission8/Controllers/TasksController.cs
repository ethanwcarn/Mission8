// =============================================================================
// [Project Manager - Your Name] - Assignment #4: Controllers / GitHub / Project Management
// Purpose: Controller(s) for Task CRUD operations.
//          Actions: Quadrants, Add/Edit, Delete, MarkComplete.
// =============================================================================

using Microsoft.AspNetCore.Mvc;
using Mission8.Data;
using MissionTask = Mission8.Models.Task;

namespace Mission8.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TasksController(ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /Tasks/Quadrants
        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = _taskRepository.GetIncompleteTasks();
            return View(tasks);
        }

        private void PopulateCategories()
        {
            ViewBag.Categories = _categoryRepository.GetAllCategories();
        }

        // GET: /Tasks/AddEdit/{id?}
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            PopulateCategories();

            if (!id.HasValue)
            {
                // Creating a new task
                var newTask = new MissionTask();
                return View(newTask);
            }

            var existingTask = _taskRepository.GetTaskById(id.Value);
            if (existingTask == null)
            {
                return NotFound();
            }

            return View(existingTask);
        }

        // POST: /Tasks/AddEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(MissionTask task)
        {
            if (!ModelState.IsValid)
            {
                PopulateCategories();
                return View(task);
            }

            if (task.TaskId == 0)
            {
                _taskRepository.AddTask(task);
            }
            else
            {
                _taskRepository.UpdateTask(task);
            }

            return RedirectToAction(nameof(Quadrants));
        }

        // GET: /Tasks/DeleteTask/{id}
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            _taskRepository.DeleteTask(id);
            return RedirectToAction(nameof(Quadrants));
        }

        // POST: /Tasks/MarkComplete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkComplete(int id)
        {
            _taskRepository.MarkTaskComplete(id);
            return RedirectToAction(nameof(Quadrants));
        }
    }
}
