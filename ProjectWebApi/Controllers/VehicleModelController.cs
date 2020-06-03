using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Common;
using Project.WebApi.ViewModels;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IModelService service;
        private readonly IMapper mapper;

        public VehicleModelController(IModelService _service, IMapper _mapper)
        {
            service = _service;
            mapper = _mapper;
        }
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<VehicleModelView> items = mapper.Map<IEnumerable<VehicleModelView>>(await service.GetAllModels());
            return Ok(items);
        }
    }
}