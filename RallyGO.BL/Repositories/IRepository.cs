namespace RallyGO.BL.Repositories;
public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task<bool> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetAsync(TKey id);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> DeleteAsync(TKey id);
}