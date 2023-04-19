using System.Linq.Expressions;
using Backend_App.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_App.Repository;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        var result = await _context.Set<TEntity>().FindAsync(id);
        return result!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.Now);
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        return result!;
    }
}