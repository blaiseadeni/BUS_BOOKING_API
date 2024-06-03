using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _CompanyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository CompanyRepository, IMapper mapper)
        {
            _CompanyRepository = CompanyRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Company>> Add([FromForm] CompanyModel request)
        {

            await _CompanyRepository.AddAsync(_mapper.Map<Company>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Company>> Update([FromBody] CompanyModel request)
        {

            await _CompanyRepository.UpdateAsync(_mapper.Map<Company>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Company>> FindAll(int id)
        {
            var items = await _CompanyRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _CompanyRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _CompanyRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
