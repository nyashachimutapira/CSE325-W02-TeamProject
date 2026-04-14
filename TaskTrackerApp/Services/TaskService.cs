using Microsoft.EntityFrameworkCore;
using TaskTrackerApp.Data;

namespace TaskTrackerApp.Services;

public class TaskService(ApplicationDbContext context)
{
    public async Task<List<TaskItem>> GetTasksAsync(string userId)
    {
        return await context.Tasks
            .Where(t => t.UserId == userId)
            .OrderBy(t => t.IsCompleted)
            .ThenBy(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id, string userId)
    {
        return await context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
    }

    public async Task AddTaskAsync(TaskItem task)
    {
        context.Tasks.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        context.Tasks.Update(task);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int id, string userId)
    {
        var task = await GetTaskByIdAsync(id, userId);
        if (task != null)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
}
