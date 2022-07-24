namespace RallyGO.BL.Api.Services;
public interface IRestService<TEntity, TKey> where TEntity : class
{
    HttpClient HttpClient { get; }
    Task<HttpResponseMessage> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetAsync(TKey id);
    Task<HttpResponseMessage> UpdateAsync(TEntity entity);
    Task<HttpResponseMessage> DeleteAsync(TKey id);
}
