using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Route = DomainLayer.Entities.Route;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _RouteRepository;
        private readonly IMapper _mapper;

        public RouteController(IRouteRepository RouteRepository, IMapper mapper)
        {
            _RouteRepository = RouteRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Route>> Add([FromBody] RouteModel request)
        {

            await _RouteRepository.AddAsync(_mapper.Map<Route>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Route>> Update([FromBody] RouteModel request)
        {

            await _RouteRepository.UpdateAsync(_mapper.Map<Route>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Route>> FindAll(int id)
        {
            var items = await _RouteRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _RouteRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _RouteRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
