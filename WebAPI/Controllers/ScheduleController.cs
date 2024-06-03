using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _ScheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository ScheduleRepository, IMapper mapper)
        {
            _ScheduleRepository = ScheduleRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Schedule>> Add([FromBody] ScheduleModel request)
        {

            await _ScheduleRepository.AddAsync(_mapper.Map<Schedule>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Schedule>> Update([FromBody] ScheduleModel request)
        {

            await _ScheduleRepository.UpdateAsync(_mapper.Map<Schedule>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Schedule>> FindAll(int id)
        {
            var items = await _ScheduleRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _ScheduleRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ScheduleRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
