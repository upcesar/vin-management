using Microsoft.AspNetCore.Mvc;
using VIN.Application.Interfaces;
using VIN.Application.ViewModel;

namespace VIN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService service;

        public VehiclesController(IVehiclesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vehicles = this.service.GetAll();

            return Ok(vehicles);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var vehicle = service.Get(id);
            return Ok(vehicle);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] VehicleViewModel vehicle)
        {
            this.service.Insert(vehicle);

            return Ok("Dados inseridos com sucesso");
        }

        // PUT api/values/
        [HttpPut]
        public IActionResult Put([FromBody] VehicleViewModel vehicle)
        {
            this.service.Update(vehicle);

            return Ok("Dados atualizado com sucesso");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            this.service.Delete(id);

            return Ok("Dados excluídos com sucesso");
        }
    }
}