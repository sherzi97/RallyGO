using Microsoft.AspNetCore.Mvc;
using RallyGO.BL.Repositories;
using RallyGO.Model.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RallyGO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        readonly DriverRepository DriverRepository;
        public DriverController(DriverRepository driverRepository)
        {
            DriverRepository = driverRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Driver>> Get() => await DriverRepository.GetAsync();

        [HttpGet("{id}")]
        public async Task<Driver> Get(int id) => await DriverRepository.GetAsync(id);

        [HttpPost]
        public async void Post([FromBody] Driver value) => await DriverRepository.AddAsync(value);

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Driver value) => await DriverRepository.UpdateAsync(value);

        [HttpDelete("{id}")]
        public async void Delete(int id) => await DriverRepository.DeleteAsync(id);
    }
}
