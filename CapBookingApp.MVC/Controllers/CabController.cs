using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.MVC.Controllers
{
    public class CabController : Controller
    {
        private readonly IUserService _userService;
        public CabController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CabModel cab)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.AddCab(cab);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CabModel cab)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.DeleteCab(cab);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CabUpdateModel cab)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateCab(cab);
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var cablist = await _userService.ListCab();
            return View(cablist);
        }
        [HttpGet]
        public async Task<IActionResult> Bookings(int id)
        {
            var moviecards = await _userService.GetBookingsByCabId(id);
            return View(moviecards);
        }
    }
}
