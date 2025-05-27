using HotelDBFinal.DomainSystem;
using HotelDBFinal.InterfaceAndServiceSystem;
using Microsoft.AspNetCore.Mvc;

namespace HotelDBFinal.ControllerSystem
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestServiceController : ControllerBase
    {
        private readonly IGuestServiceService _guestServiceService;

        public GuestServiceController(IGuestServiceService guestServiceService)
        {
            _guestServiceService = guestServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _guestServiceService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _guestServiceService.GetByIdAsync(id);
            return service == null ? NotFound() : Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GuestServiceNew guestServiceNew)
        {
            var id = await _guestServiceService.CreateAsync(guestServiceNew);
            return CreatedAtAction(nameof(GetById), new { id }, guestServiceNew);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GuestServiceNew guestServiceNew)
        {
            if (id != guestServiceNew.GuestServiceId) return BadRequest();
            var updated = await _guestServiceService.UpdateAsync(guestServiceNew);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _guestServiceService.DeleteAsync(id);
            return deleted ? Ok() : NotFound();
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedAndFiltered(
            int page = 1,
            int pageSize = 10,
            int? bookingId = null,
            int? serviceId = null)
        {
            var result = await _guestServiceService.GetPagedAndFilteredAsync(page, pageSize, bookingId, serviceId);
            return Ok(result);
        }
    }
}