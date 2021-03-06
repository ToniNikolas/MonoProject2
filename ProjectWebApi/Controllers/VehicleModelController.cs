﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Common.Functionalities;
using Project.DAL.DatabaseModels;
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
        public async Task<IActionResult> GetAllAsync(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            Sorting sorting = new Sorting();
            Searching searching = new Searching();
            if (searchString != null) { pageNumber = 1; }
            else { searchString = currentFilter; }
            PaginatedList<VehicleModel> paging = new PaginatedList<VehicleModel>();
            sorting.SortString = sortOrder;
            searching.SearchingString = searchString;
            paging.PageNumber = pageNumber ?? 1;

            IEnumerable<VehicleModelView> items = _mapper.Map<IEnumerable<VehicleModelView>>(await _service.GetAllModelsAsync(sorting,searching,paging));
            PaginatedList<VehicleModelView> getPaginatedList = new PaginatedList<VehicleModelView>(items, paging.PageCount, paging.PageNumber, Strings.PageSize);
            return Ok(getPaginatedList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(VehicleModelView vehicle)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _service.InsertModelAsync(_mapper.Map<IVehicleModelDomain>(vehicle));
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

            VehicleModelView getVehicle = _mapper.Map<VehicleModelView>(await _service.GetIdModelAsync(id));

            if (getVehicle == null) { return NotFound(); }

            return Ok(getVehicle);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAsync(Guid? id, VehicleModelView vehicle)
        {

            try
            {

                if (id == null) { return BadRequest(); }

                IVehicleModelDomain vehicleUpdate = await _service.GetIdModelAsync(vehicle.Id);

                if (vehicleUpdate == null) { return NotFound(); }

                if (ModelState.IsValid)
                { 
                    await _service.UpdateModelAsync(_mapper.Map<IVehicleModelDomain>(vehicle));
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

                await _service.DeleteModelAsync(id);
            }
            catch
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}