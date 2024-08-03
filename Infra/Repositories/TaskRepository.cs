using Domain.Interfaces;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Infra.Repositories;

public sealed class TaskRepository : ITaskRepository
{
    private readonly ToDoDatabaseContext _db;

    public TaskRepository(ToDoDatabaseContext db)
    {
        _db = db;
    }

    public async Task<Entities.Task> CreateAsync(Entities.Task task)
    {
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();

        return task;
    }

    public async Task<IEnumerable<Entities.Task>> GetAllAsync()
    {
        return await _db.Tasks.ToListAsync();
    }

    public async Task<Entities.Task?> GetByIdAsync(int id)
    {
        return await _db.Tasks.FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<Entities.Task> UpdateAsync(Entities.Task task)
    {
        _db.Tasks.Update(task);

        await _db.SaveChangesAsync();

        return task;
    }

    public async Task<bool> DeleteAsync(Entities.Task task)
    {
        _db.Tasks.Remove(task);

        var affectedRows = await _db.SaveChangesAsync();

        return (affectedRows >= 1);
    }
}
