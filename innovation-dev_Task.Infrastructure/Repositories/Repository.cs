using innovation_dev_Task.Application.Interfaces;
using innovation_dev_Task.Domain.Entities;
using innovation_dev_Task.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : BaseClass
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<T> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids)
    {
        if (ids == null || !ids.Any())
        {
            return Enumerable.Empty<T>();
        }

        return await _dbSet
            .Where(e => ids.Contains(e.Id))
            .AsNoTracking()
            .ToListAsync();
    }
    public void Attach<T>(T entity)
    {
        _context.Entry(entity).State = EntityState.Unchanged;
    }
}
