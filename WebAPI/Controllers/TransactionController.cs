using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepository TransactionRepository, IMapper mapper)
        {
            _TransactionRepository = TransactionRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Transaction>> Add([FromBody] TransactionModel request)
        {

            await _TransactionRepository.AddAsync(_mapper.Map<Transaction>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Transaction>> Update([FromBody] TransactionModel request)
        {

            await _TransactionRepository.UpdateAsync(_mapper.Map<Transaction>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Transaction>> FindAll(int id)
        {
            var items = await _TransactionRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _TransactionRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _TransactionRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
