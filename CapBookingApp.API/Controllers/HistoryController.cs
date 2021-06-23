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
    public class HistoryController : ControllerBase
    {
        private readonly IUserService _userService;
        public HistoryController(IUserService userService)
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
        public async Task<IActionResult> Add([FromBody]HistoryModel history)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddHistory(history);
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
        public async Task<IActionResult> Delete([FromBody]HistoryModel b)
        {
            if (ModelState.IsValid)
            {
                await _userService.DeleteHistory(b);
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
        public async Task<IActionResult> Update([FromBody] HistoryModel h)
        {

            if (ModelState.IsValid)
            {
                await _userService.UpdateHistory(h);
                return Ok();
            }
            return BadRequest("Please check input");
        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var historylist = await _userService.ListHistory();
            if (historylist == null)
            {
                return NotFound("No history found ");
            }
            return Ok(historylist);
        }
        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var b = await _userService.GetHistoryDetails(id);
            if (b == null)
            {
                return NotFound("No history details found");
            }
            return Ok(b);
        }
    }
}
