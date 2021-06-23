using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUserService _userService;
        public BookingController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookingModel booking)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.AddBooking(booking);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BookingModel b)
        {
            
            await _userService.DeleteBooking(b);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateBooking(booking);
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var bookinglist = await _userService.ListBooking();
            return View(bookinglist);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var b = await _userService.GetBookingDetails(id);
            return View(b);
        }
    }
}
