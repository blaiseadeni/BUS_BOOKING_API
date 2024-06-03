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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository CustomerRepository, IMapper mapper)
        {
            _CustomerRepository = CustomerRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> Add([FromBody] CustomerModel request)
        {

            await _CustomerRepository.AddAsync(_mapper.Map<Customer>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> Update([FromBody] CustomerModel request)
        {

            await _CustomerRepository.UpdateAsync(_mapper.Map<Customer>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Customer>> FindAll(int id)
        {
            var items = await _CustomerRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _CustomerRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _CustomerRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
