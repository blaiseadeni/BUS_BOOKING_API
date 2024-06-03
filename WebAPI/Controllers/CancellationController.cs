using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancellationController : ControllerBase
    {
        private readonly ICancellationRepository _CancellationRepository;
        private readonly IMapper _mapper;

        public CancellationController(ICancellationRepository CancellationRepository, IMapper mapper)
        {
            _CancellationRepository = CancellationRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Cancellation>> Add([FromBody] CancellationModel request)
        {

            await _CancellationRepository.AddAsync(_mapper.Map<Cancellation>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Cancellation>> Update([FromBody] CancellationModel request)
        {

            await _CancellationRepository.UpdateAsync(_mapper.Map<Cancellation>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Cancellation>> FindAll(int id)
        {
            var items = await _CancellationRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _CancellationRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _CancellationRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
