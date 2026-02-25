// =============================================================================
// JARED - Assignment #1: Models / Database / Setup
// Purpose: Repository interface for Task operations (Repository Pattern).
// =============================================================================

using Mission8.Models;
using MissionTask = Mission8.Models.Task;

namespace Mission8.Data
{
    public interface ITaskRepository
    {
        IQueryable<MissionTask> Tasks { get; }

        IEnumerable<MissionTask> GetIncompleteTasks();
        MissionTask? GetTaskById(int taskId);
        void AddTask(MissionTask task);
        void UpdateTask(MissionTask task);
        void DeleteTask(int taskId);
        void MarkTaskComplete(int taskId);
        void SaveTask();
    }
}
