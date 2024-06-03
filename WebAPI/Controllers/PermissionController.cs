using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _PermissionRepository;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionRepository PermissionRepository, IMapper mapper)
        {
            _PermissionRepository = PermissionRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Permission>> Add([FromBody] PermissionModel request)
        {
            await _PermissionRepository.AddAsync(_mapper.Map<Permission>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Permission>> Update([FromBody] PermissionModel request)
        {

            await _PermissionRepository.UpdateAsync(_mapper.Map<Permission>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Permission>> FindAll(int id)
        {
            var items = await _PermissionRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _PermissionRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _PermissionRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
