using RallyGO.Model.Entities;

namespace RallyGO.BL.Repositories;
public interface IDriverRepository : IRepository<Driver, int>
{
    public Task<IEnumerable<Driver>> Search(string name);
}
