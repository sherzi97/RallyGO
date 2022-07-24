namespace RallyGO.BL.Api.Services;
public class BaseRestService<TEntity, TKey> : IRestService<TEntity, TKey> where TEntity : class
{
    public BaseRestService(string baseAddress)
    {
        HttpClient = new HttpClient() { BaseAddress = new Uri(baseAddress)};
    }

    public HttpClient HttpClient { get; }

    public Task<HttpResponseMessage> AddAsync(TEntity entity) => Execute((client) => client.PostAsJsonAsync("", entity));

    public Task<HttpResponseMessage> DeleteAsync(TKey id) => Execute((client) => client.DeleteAsync(""));

    public async Task<IEnumerable<TEntity>> GetAsync() => await ExecuteWithResponse<IEnumerable<TEntity>>((client) => client.GetAsync(""));

    public async Task<TEntity> GetAsync(TKey id) => await ExecuteWithResponse<TEntity>((client) => client.GetAsync(""));

    public Task<HttpResponseMessage> UpdateAsync(TEntity entity) => Execute((client) => client.PutAsJsonAsync("", entity));

    async Task<HttpResponseMessage> Execute(Func<HttpClient, Task<HttpResponseMessage>> execute)
    {
        var response = await execute(HttpClient);
        response.EnsureSuccessStatusCode();
        return response;
    }

    async Task<TResponse> ExecuteWithResponse<TResponse>(Func<HttpClient, Task<HttpResponseMessage>> execute)
    {
        var response = await Execute(execute);
        return await response.Content.ReadAsAsync<TResponse>();
    }
}
