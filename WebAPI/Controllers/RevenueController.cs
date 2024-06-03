using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueRepository _RevenueRepository;
        private readonly IMapper _mapper;

        public RevenueController(IRevenueRepository RevenueRepository, IMapper mapper)
        {
            _RevenueRepository = RevenueRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Revenue>> Add([FromBody] RevenueModel request)
        {

            await _RevenueRepository.AddAsync(_mapper.Map<Revenue>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Revenue>> Update([FromBody] RevenueModel request)
        {

            await _RevenueRepository.UpdateAsync(_mapper.Map<Revenue>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Revenue>> FindAll(int id)
        {
            var items = await _RevenueRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _RevenueRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _RevenueRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
