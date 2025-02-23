using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectMain.Data;

namespace ProjectMain.Repositories;

public class Repository<T> : IRepository<T> where T : class {
    private readonly AppDbContext context;
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext context) {
        this.context = context;
        this.dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id) {
        return await dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync() {
        return await dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity) {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity) {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id) {
        var entity = await GetByIdAsync(id);
        if (entity != null) {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<T?> GetByFieldAsync(Expression<Func<T, bool>> expression) {
        return await dbSet.FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<T>> GetManyByFieldAsync(Expression<Func<T, bool>> expression) {
        return await dbSet.Where(expression).ToListAsync();
    }
}