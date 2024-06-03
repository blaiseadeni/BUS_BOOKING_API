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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _ExpenseRepository;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseRepository ExpenseRepository, IMapper mapper)
        {
            _ExpenseRepository = ExpenseRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Expense>> Add([FromBody] ExpenseModel request)
        {

            await _ExpenseRepository.AddAsync(_mapper.Map<Expense>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Expense>> Update([FromBody] ExpenseModel request)
        {

            await _ExpenseRepository.UpdateAsync(_mapper.Map<Expense>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Expense>> FindAll(int id)
        {
            var items = await _ExpenseRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _ExpenseRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ExpenseRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
