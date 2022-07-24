using RallyGO.Model.Entities;

namespace RallyGO.DAL.Services;
public class DriverMockDalService : MockDalService<Driver, int>
{
    public DriverMockDalService() : base(GetData(), (driver, id) => driver.Id == id)
    {
    }

    static List<Driver> GetData() => new List<Driver>()
    {
        new Driver(){Id = 1, FirstName = "Sheraz", LastName = "Muhammad"}
    };
}