using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashRegisterController : ControllerBase
    {
        private readonly ICashRegisterRepository _CashRegisterRepository;
        private readonly IMapper _mapper;

        public CashRegisterController(ICashRegisterRepository CashRegisterRepository, IMapper mapper)
        {
            _CashRegisterRepository = CashRegisterRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<CashRegister>> Add([FromBody] CashRegisterModel request)
        {

            await _CashRegisterRepository.AddAsync(_mapper.Map<CashRegister>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<CashRegister>> Update([FromBody] CashRegisterModel request)
        {

            await _CashRegisterRepository.UpdateAsync(_mapper.Map<CashRegister>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<CashRegister>> FindAll(int id)
        {
            var items = await _CashRegisterRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _CashRegisterRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _CashRegisterRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
