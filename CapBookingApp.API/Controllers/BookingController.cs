using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUserService _userService;
        public BookingController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return Ok();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody]BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddBooking(booking);
                return Ok();
            }
            return BadRequest("Please check input");
        }
        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete()
        {
            return Ok();
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] BookingModel b)
        {
            if (ModelState.IsValid)
            {
                await _userService.DeleteBooking(b);
                return Ok();
            }
            return BadRequest("Please check input");
        }
        [HttpGet]
        [Route("Update")]
        public IActionResult Update()
        {
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateBooking(booking);
                return Ok();
            }
            return BadRequest("Please check input");
        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var bookinglist = await _userService.ListBooking();
            if (bookinglist == null)
            {
                return NotFound("No booking found ");
            }
            return Ok(bookinglist);
        }
        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var b = await _userService.GetBookingDetails(id);
            if (b == null)
            {
                return NotFound("No booking details found");
            }
            return Ok(b);
        }
    }
}
