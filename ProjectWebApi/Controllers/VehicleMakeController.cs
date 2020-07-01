using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Common.Functionalities;
using Project.DAL.Common.DatabaseInterfaces;
using Project.DAL.DatabaseModels;
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
        public async Task<IActionResult> GetAllAsync(string sortOrder,string currentFilter, string searchString, int? pageNumber)
        {
            Sorting sorting = new Sorting();
            Searching searching = new Searching();
            if (searchString != null) { pageNumber = 1; }
            else { searchString = currentFilter; }
            PaginatedList<VehicleMake> paging = new PaginatedList<VehicleMake>();
            sorting.SortString = sortOrder;
            searching.SearchingString = searchString;
            paging.PageNumber = pageNumber ?? 1;

            IEnumerable<VehicleMakeView> items = _mapper.Map<IEnumerable<VehicleMakeView>>(await _service.GetAllMakesAsync(sorting,searching,paging));
            PaginatedList<VehicleMakeView> getPaginatedList = new PaginatedList<VehicleMakeView>(items, paging.PageCount, paging.PageNumber, Strings.PageSize);
            return Ok(getPaginatedList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(VehicleMakeView vehicle)
        {
            try
            {

                if(ModelState.IsValid)
                 {
                    await _service.InsertMakeAsync(_mapper.Map<IVehicleMakeDomain>(vehicle));
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
        public async Task<IActionResult> GetAsync(Guid? id)
        {
            if (id == null) { return BadRequest(); }

            VehicleMakeView getVehicle = _mapper.Map<VehicleMakeView>(await _service.GetIdMakeAsync(id));

            if (getVehicle == null) { return NotFound(); }

            return Ok(getVehicle);
        }


        [HttpPut("{id}")]
    
        public async Task<IActionResult> UpdateAsync(Guid? id, VehicleMakeView vehicle)
        {

            try
            {

                if (id == null) { return BadRequest(); }

                IVehicleMakeDomain vehicleUpdate =await _service.GetIdMakeAsync(vehicle.Id);

                if (vehicleUpdate == null){return NotFound();}

                if (ModelState.IsValid)
                {
                    await _service.UpdateMakeAsync(_mapper.Map<IVehicleMakeDomain>(vehicle));
                }

            }

            catch
            {
                return NotFound();
            }

          return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid? id)
        {
            try
            {
               if (id == null)
               {
                    return BadRequest();
               }

                await _service.DeleteMakeAsync(id);
            }
            catch
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}