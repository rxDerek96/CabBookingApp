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
    public class CabController : ControllerBase
    {
        private readonly IUserService _userService;
        public CabController(IUserService userService)
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
        public async Task<IActionResult> Add([FromBody] CabModel cab)
        {

            if (ModelState.IsValid)
            {
                await _userService.AddCab(cab);
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
        public async Task<IActionResult> Delete([FromBody] CabModel cab)
        {
            if (ModelState.IsValid)
            {
                await _userService.DeleteCab(cab);
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
        public async Task<IActionResult> Update([FromBody] CabUpdateModel cab)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateCab(cab);
                return Ok();
            }
            return BadRequest("Please check input");
        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var cablist = await _userService.ListCab();
            if (cablist == null)
            {
                return NotFound("No cab found ");
            }
            return Ok(cablist);
        }
        [HttpGet]
        [Route("Bookings")]
        public async Task<IActionResult> Bookings(int id)
        {
            var bookings = await _userService.GetBookingsByCabId(id);
            if (bookings == null)
            {
                return NotFound("No booking found for this cab");
            }
            return Ok(bookings);
        }
    }
}