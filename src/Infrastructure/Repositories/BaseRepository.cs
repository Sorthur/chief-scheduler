using System.Linq;
using System.Linq.Expressions;
using chief_schedule.Application.Common.Interfaces.Repositories;
using chief_schedule.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace chief_schedule.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected DbSet<TEntity> _entities;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _entities;
    }

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _entities.Where(predicate);
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entity = await _entities.FindAsync(id);
        _entities.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}