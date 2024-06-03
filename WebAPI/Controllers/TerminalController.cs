using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalRepository _TerminalRepository;
        private readonly IMapper _mapper;

        public TerminalController(ITerminalRepository TerminalRepository, IMapper mapper)
        {
            _TerminalRepository = TerminalRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Terminal>> Add([FromBody] TerminalModel request)
        {

            await _TerminalRepository.AddAsync(_mapper.Map<Terminal>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Terminal>> Update([FromBody] TerminalModel request)
        {

            await _TerminalRepository.UpdateAsync(_mapper.Map<Terminal>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Terminal>> FindAll(int id)
        {
            var items = await _TerminalRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _TerminalRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _TerminalRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
