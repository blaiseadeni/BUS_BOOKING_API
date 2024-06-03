using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopoverController : ControllerBase
    {
        private readonly IStopoverRepository _StopoverRepository;
        private readonly IMapper _mapper;

        public StopoverController(IStopoverRepository StopoverRepository, IMapper mapper)
        {
            _StopoverRepository = StopoverRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Stopover>> Add([FromBody] StopoverModel request)
        {

            await _StopoverRepository.AddAsync(_mapper.Map<Stopover>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Stopover>> Update([FromBody] StopoverModel request)
        {

            await _StopoverRepository.UpdateAsync(_mapper.Map<Stopover>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Stopover>> FindAll(int id)
        {
            var items = await _StopoverRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _StopoverRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _StopoverRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
