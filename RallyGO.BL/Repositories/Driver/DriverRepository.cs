using Microsoft.EntityFrameworkCore;
using RallyGO.DAL.Services;
using RallyGO.Model.Entities;

namespace RallyGO.BL.Repositories;
public class DriverRepository : RepositoryBase<Driver, int>, IDriverRepository
{
    public DriverRepository(IDalService<Driver, int> dalService) : base(dalService)
    {
    }

    public async Task<IEnumerable<Driver>> Search(string name)
    {
        var entities = await DalService.GetAsync();
        return entities.Where(d => d.LastName.Contains(name));
    }
}
