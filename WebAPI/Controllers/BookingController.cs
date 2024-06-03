using ApplicationLayer.Contacts;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;
using InfrastrutureLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _BookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository BookingRepository, IMapper mapper)
        {
            _BookingRepository = BookingRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Add([FromBody] BookingModel request)
        {

            await _BookingRepository.AddAsync(_mapper.Map<Booking>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut]
        public async Task<ActionResult<Booking>> Update([FromBody] BookingModel request)
        {

            await _BookingRepository.UpdateAsync(_mapper.Map<Booking>(request));
            return Ok("Updated successfully");
        }

        [HttpGet("All/{id:int}")]
        public async Task<ActionResult<Booking>> FindAll(int id)
        {
            var items = await _BookingRepository.FindAllAsync(id);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Find(int id)
        {
            var result = await _BookingRepository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _BookingRepository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
