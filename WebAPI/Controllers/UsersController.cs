using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<User>> Add([FromBody] UserModel request)
        {

            await _userRepository.AddAsync(_mapper.Map<User>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] UserModel request)
        {
          
            await _userRepository.UpdateAsync(_mapper.Map<User>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<User>> FindAll(int id)
        {
            var items = await _userRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _userRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
