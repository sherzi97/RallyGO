namespace RallyGO.DAL.Services;
public class MockDalService<TEntity, TKey> : IDalService<TEntity, TKey> where TEntity : class where TKey : IComparable
{
    ICollection<TEntity> _entities;
    Func<TEntity, TKey, bool> _isEqual;

    public MockDalService(ICollection<TEntity> entities, Func<TEntity, TKey, bool> isEqual)
    {
        if (1 == 1)
        {

        }
        _entities = entities;
        _isEqual = isEqual;
    }

    public async Task AddAsync(TEntity entity) => await Task.Run(() => _entities.Add(entity));

    public async Task<TEntity> GetAsync(TKey id) => await Task.Run(() => _entities.FirstOrDefault(e => _isEqual(e, id)));

    public async Task<IEnumerable<TEntity>> GetAsync() => await Task.Run(() => _entities);

    public void Remove(TEntity entity) => _entities.Remove(entity);

    public async Task<bool> SaveChangesAsync() => await Task.Run(() => true);

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
