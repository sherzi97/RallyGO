using Microsoft.EntityFrameworkCore;

namespace RallyGO.DAL.Services;
public class DbDalService<TEntity, TKey> : IDalService<TEntity, TKey> where TEntity : class
{
    protected readonly DbContext _dbContext;

    public DbDalService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity) => await DbSet.AddAsync(entity);

    public async Task<TEntity> GetAsync(TKey id) => await DbSet.FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetAsync() => await DbSet.ToListAsync();

    public void Remove(TEntity entity) => DbSet.Remove(entity);

    public async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() > 0;

    public async Task<IEnumerable<TEntity>> ToListAsync() => await DbSet.ToListAsync();

    public void Update(TEntity entity) => DbSet.Update(entity);
}
