using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public AgencyController(IAgencyRepository AgencyRepository, IMapper mapper)
        {
            _agencyRepository = AgencyRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Agency>> Add([FromBody] AgencyModel request)
        {

            await _agencyRepository.AddAsync(_mapper.Map<Agency>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Agency>> Update([FromBody] AgencyModel request)
        {

            await _agencyRepository.UpdateAsync(_mapper.Map<Agency>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Agency>> FindAll(int id)
        {
            var items = await _agencyRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _agencyRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _agencyRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
