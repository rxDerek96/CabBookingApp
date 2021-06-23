using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.MVC.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IUserService _userService;
        public HistoryController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(HistoryModel history)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.AddHistory(history);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(HistoryModel b)
        {

            await _userService.DeleteHistory(b);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(HistoryModel booking)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateHistory(booking);
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var historylist = await _userService.ListHistory();
            return View(historylist);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var b = await _userService.GetHistoryDetails(id);
            return View(b);
        }
    }
}
