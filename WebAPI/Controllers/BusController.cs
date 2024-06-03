using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _BusRepository;
        private readonly IMapper _mapper;

        public BusController(IBusRepository BusRepository, IMapper mapper)
        {
            _BusRepository = BusRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Bus>> Add([FromBody] BusModel request)
        {

            await _BusRepository.AddAsync(_mapper.Map<Bus>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Bus>> Update([FromBody] BusModel request)
        {

            await _BusRepository.UpdateAsync(_mapper.Map<Bus>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Bus>> FindAll(int id)
        {
            var items = await _BusRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _BusRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _BusRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
