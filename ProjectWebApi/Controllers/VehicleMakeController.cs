using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class VehicleMakeController : ControllerBase
    {
        private readonly IMakeService service;
        private readonly IMapper mapper;

        public VehicleMakeController(IMakeService _service, IMapper _mapper)
        {
            service = _service;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<VehicleMakeView> items = mapper.Map<List<VehicleMakeView>>(await service.GetAllMakes());
            return Ok(items);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}