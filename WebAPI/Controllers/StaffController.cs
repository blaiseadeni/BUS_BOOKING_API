using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _StaffRepository;
        private readonly IMapper _mapper;

        public StaffController(IStaffRepository StaffRepository, IMapper mapper)
        {
            _StaffRepository = StaffRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Staff>> Add([FromForm] StaffModel request)
        {

            await _StaffRepository.AddAsync(_mapper.Map<Staff>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Staff>> Update([FromBody] StaffModel request)
        {

            await _StaffRepository.UpdateAsync(_mapper.Map<Staff>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Staff>> FindAll(int id)
        {
            var items = await _StaffRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _StaffRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _StaffRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
