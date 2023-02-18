using System.Linq.Expressions;

namespace chief_schedule.Application.Common.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> GetAll();

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

    public Task<TEntity?> GetById(int id);

    public Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    public Task AddAsync(TEntity entity);

    public Task DeleteByIdAsync(int id);

    public void Update(TEntity entity);

    public Task SaveChangesAsync();
}