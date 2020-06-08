using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Model.Common.DomainInterfaces;
using Project.Service.Common;
using Project.WebApi.ViewModels;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IModelService _service;
        private readonly IMapper _mapper;

        public VehicleModelController(IModelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<ActionResult<IEnumerable<VehicleMakeView>>> GetAll()
        {
            IEnumerable<VehicleModelView> items = _mapper.Map<IEnumerable<VehicleModelView>>(await _service.GetAllModels());
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Create(VehicleModelView vehicle)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _service.InsertModel(_mapper.Map<IVehicleModelDomain>(vehicle));
                    return Ok();
                }

                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModelView>> Get(Guid? id)
        {
            if (id == null) { return BadRequest(); }

            VehicleModelView getVehicle = _mapper.Map<VehicleModelView>(await _service.GetIdModel(id));

            if (getVehicle == null) { return NotFound(); }

            return Ok(getVehicle);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult> Update(Guid? id, VehicleModelView vehicle)
        {

            try
            {

                if (id == null) { return BadRequest(); }

                IVehicleModelDomain vehicleUpdate = await _service.GetIdModel(vehicle.Id);

                if (vehicleUpdate == null) { return NotFound(); }

                if (ModelState.IsValid)
                {
                    vehicleUpdate.MakeId = vehicle.MakeId;
                    vehicleUpdate.ModelName = vehicle.ModelName;
                    vehicleUpdate.Abrv = vehicle.Abrv;
                    await _service.UpdateModel(vehicleUpdate);
                }

            }

            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                await _service.DeleteModel(id);
            }
            catch
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}