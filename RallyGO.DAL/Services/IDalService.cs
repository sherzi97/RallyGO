namespace RallyGO.DAL.Services;
public interface IDalService<TEntity, TKey> where TEntity : class
{
    Task AddAsync(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity> GetAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAsync();
    void Update(TEntity entity);
    public Task<bool> SaveChangesAsync();
}
