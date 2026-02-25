# Mission 8 - Assignment #1 Handoff (Models / Database / Setup)

This branch contains only the work for **Responsibility #1**:
- Models
- Database context + seed data
- Repository pattern interfaces/implementations
- App setup in `Program.cs`

## What Was Added

### 1) Data Models
Location:
- `Mission8/Models/Task.cs`
- `Mission8/Models/Category.cs`

`Task` model fields:
- `TaskId` (PK)
- `TaskName` (required)
- `DueDate` (nullable)
- `Quadrant` (required, 1-4)
- `CategoryId` (required FK)
- `Category` (navigation property)
- `Completed` (bool)

`Category` model fields:
- `CategoryId` (PK)
- `CategoryName` (required)
- `Tasks` (navigation collection)

### 2) Database Context + Seed Data
Location:
- `Mission8/Data/Mission8Context.cs`

Includes:
- `DbSet<Task> Tasks`
- `DbSet<Category> Categories`

Seeded Categories (required by assignment):
- Home
- School
- Work
- Church

Also seeded a few starter tasks for local/dev testing.

### 3) Repository Pattern
Location:
- `Mission8/Data/ITaskRepository.cs`
- `Mission8/Data/TaskRepository.cs`
- `Mission8/Data/ICategoryRepository.cs`
- `Mission8/Data/CategoryRepository.cs`

Implemented methods teammate code can call:

`ITaskRepository`:
- `IQueryable<Task> Tasks`
- `IEnumerable<Task> GetIncompleteTasks()`
- `Task? GetTaskById(int taskId)`
- `void AddTask(Task task)`
- `void UpdateTask(Task task)`
- `void DeleteTask(int taskId)`
- `void MarkTaskComplete(int taskId)`
- `void SaveTask()`

`ICategoryRepository`:
- `IQueryable<Category> Categories`
- `IEnumerable<Category> GetAllCategories()`

### 4) Program Setup
Location:
- `Mission8/Program.cs`
- `Mission8/appsettings.json`

Configured:
- SQLite connection string: `Mission8Connection`
- `Mission8Context` registration with EF Core
- DI registrations:
  - `ITaskRepository -> TaskRepository`
  - `ICategoryRepository -> CategoryRepository`
- Database auto-create on startup:
  - `dbContext.Database.EnsureCreated()`

### 5) Package Dependencies
Location:
- `Mission8/Mission8.csproj`

Added EF Core packages:
- `Microsoft.EntityFrameworkCore.Sqlite` (10.0.0)
- `Microsoft.EntityFrameworkCore.Design` (10.0.0)

## Integration Notes For Teammates

### For Controller Owner (#4)
- Inject both repositories in `TasksController` constructor:
  - `ITaskRepository`
  - `ICategoryRepository`
- Use `GetIncompleteTasks()` for the Quadrants page so completed tasks are excluded.
- Use `MarkTaskComplete(taskId)` for Complete action.
- Use `DeleteTask(taskId)` for Delete action.
- Use `GetTaskById(taskId)` for Edit GET.
- Use `AddTask` and `UpdateTask` for POST actions.

### For Add/Edit View Owner (#2)
- `Category` dropdown should bind to `CategoryId`.
- Display label as `CategoryName`.
- `Quadrant` input should enforce values 1-4.
- `TaskName` and `Quadrant` are required.

### For Quadrants View Owner (#3)
- Group tasks by `Quadrant` from `GetIncompleteTasks()`.
- Use Bootstrap grid to lay out Quadrants I-IV.
- Include actions:
  - Edit
  - Delete
  - Mark Complete

## Local Setup Steps
1. Run `dotnet restore`.
2. Run `dotnet run` from the `Mission8` project folder.
3. On first run, `Mission8.db` is created automatically with seeded data.

## Notes
- I intentionally limited changes to Assignment #1 scope.
- Remaining controller/view implementation should be completed on teammates' branches and merged by the project manager.
