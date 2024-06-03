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
    public class CashTransactionController : ControllerBase
    {
        private readonly ICashTransactionRepository _CashTransactionRepository;
        private readonly IMapper _mapper;

        public CashTransactionController(ICashTransactionRepository CashTransactionRepository, IMapper mapper)
        {
            _CashTransactionRepository = CashTransactionRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<CashTransaction>> Add([FromBody] CashTransactionModel request)
        {

            await _CashTransactionRepository.AddAsync(_mapper.Map<CashTransaction>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<CashTransaction>> Update([FromBody] CashTransactionModel request)
        {

            await _CashTransactionRepository.UpdateAsync(_mapper.Map<CashTransaction>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<CashTransaction>> FindAll(int id)
        {
            var items = await _CashTransactionRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _CashTransactionRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _CashTransactionRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
