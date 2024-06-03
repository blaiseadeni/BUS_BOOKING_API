using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository AccountRepository, IMapper mapper)
        {
            _AccountRepository = AccountRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Account>> Add([FromBody] AccountModel request)
        {

            await _AccountRepository.AddAsync(_mapper.Map<Account>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Account>> Update([FromBody] AccountModel request)
        {

            await _AccountRepository.UpdateAsync(_mapper.Map<Account>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Account>> FindAll(int id)
        {
            var items = await _AccountRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _AccountRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _AccountRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
