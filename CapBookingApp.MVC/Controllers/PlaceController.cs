using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.MVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IUserService _userService;

        public PlaceController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PlaceModel place)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.AddPlace(place);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(PlaceModel place)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.DeletePlace(place);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(PlaceUpdateModel place)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdatePlace(place);
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var placelist = await _userService.ListPlace();
            return View(placelist);
        }
    }
}
