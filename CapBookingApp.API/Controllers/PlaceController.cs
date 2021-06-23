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
    public class PlaceController : ControllerBase
    {
        private readonly IUserService _userService;

        public PlaceController(IUserService userService)
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
        public async Task<IActionResult> Add([FromBody]PlaceModel place)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddPlace(place);
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
        public async Task<IActionResult> Delete([FromBody]PlaceModel place)
        {
            if (ModelState.IsValid)
            {
                await _userService.DeletePlace(place);
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
        public async Task<IActionResult> Update([FromBody]PlaceUpdateModel place)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdatePlace(place);
                return Ok();
            }
            return BadRequest("Please check input");
        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var placelist = await _userService.ListPlace();
            if (placelist == null)
            {
                return NotFound("No booking found ");
            }
            return Ok(placelist);
        }
    }
}
