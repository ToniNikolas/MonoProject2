using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Model.Common.DomainInterfaces;
using Project.Model.DomainModels;
using Project.Service.Common;
using Project.WebApi.ViewModels;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IMakeService _service;
        private readonly IMapper _mapper;

        public VehicleMakeController(IMakeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMakeView>>> GetAll()
        {
            IEnumerable<VehicleMakeView> vehicles = _mapper.Map<IEnumerable<VehicleMakeView>>(await _service.GetAllMakes());
            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<ActionResult> Create(VehicleMakeView vehicle)
        {
            try
            {

                if(ModelState.IsValid)
                 {
                    await _service.InsertMake(_mapper.Map<IVehicleMakeDomain>(vehicle));
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
        public async Task<ActionResult<VehicleMakeView>> Get(Guid? id)
        {
            if (id == null) { return BadRequest(); }

            VehicleMakeView getVehicle = _mapper.Map<VehicleMakeView>(await _service.GetIdMake(id));

            if (getVehicle == null) { return NotFound(); }

            return Ok(getVehicle);
        }


        [HttpPut("{id}")]
    
        public async Task<ActionResult> Update(Guid? id, VehicleMakeView vehicle)
        {

            try
            {

                if (id == null) { return BadRequest(); }

                IVehicleMakeDomain vehicleUpdate =await _service.GetIdMake(vehicle.Id);

                if (vehicleUpdate == null){return NotFound();}

                if (ModelState.IsValid)
                {
                    vehicleUpdate.Name = vehicle.Name;
                    vehicleUpdate.Abrv = vehicle.Abrv;
                    await _service.UpdateMake(vehicleUpdate);
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

                await _service.DeleteMake(id);
            }
            catch
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}