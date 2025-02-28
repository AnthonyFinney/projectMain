using System.Linq.Expressions;
using ProjectMain.Models;

namespace ProjectMain.Repositories;

public interface IRepository<T> where T : class {
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T?> GetByFieldAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetManyByFieldAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    Task DeleteAsync(Guid id);
}