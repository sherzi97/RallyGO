using RallyGO.DAL.Services;

namespace RallyGO.BL.Repositories;
public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    public readonly IDalService<TEntity, TKey> DalService;

    public RepositoryBase(IDalService<TEntity, TKey> dalService)
    {
        DalService = dalService;
    }

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        await DalService.AddAsync(entity);
        return await DalService.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        DalService.Remove(entity);
        return await DalService.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(TKey id)
    {
        TEntity entity = await GetAsync(id);
        return await DeleteAsync(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAsync() => await DalService.GetAsync();

    public async Task<TEntity> GetAsync(TKey id) => await DalService.GetAsync(id);

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        DalService.Update(entity);
        return await DalService.SaveChangesAsync();
    }
}
