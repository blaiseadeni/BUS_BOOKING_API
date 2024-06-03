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
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository RoleRepository, IMapper mapper)
        {
            _RoleRepository = RoleRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Role>> Add([FromBody] RoleModel request)
        {

            await _RoleRepository.AddAsync(_mapper.Map<Role>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Role>> Update([FromBody] RoleModel request)
        {

            await _RoleRepository.UpdateAsync(_mapper.Map<Role>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Role>> FindAll(int id)
        {
            var items = await _RoleRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _RoleRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _RoleRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
