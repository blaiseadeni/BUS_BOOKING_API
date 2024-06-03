using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionRepository _RolePermissionRepository;
        private readonly IMapper _mapper;

        public RolePermissionController(IRolePermissionRepository RolePermissionRepository, IMapper mapper)
        {
            _RolePermissionRepository = RolePermissionRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<RolePermission>> Add([FromBody] RolePermissionModel request)
        {

            await _RolePermissionRepository.AddAsync(_mapper.Map<RolePermission>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<RolePermission>> Update([FromBody] RolePermissionModel request)
        {

            await _RolePermissionRepository.UpdateAsync(_mapper.Map<RolePermission>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<RolePermission>> FindAll(int id)
        {
            var items = await _RolePermissionRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _RolePermissionRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _RolePermissionRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
