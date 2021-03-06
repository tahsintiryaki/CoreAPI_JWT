using JWT_Example.Web.APIService;
using JWT_Example.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Example.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserAPIService _userApiService;

        public HomeController(ILogger<HomeController> logger, UserAPIService userApiService)
        {
            _logger = logger;
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _userApiService.GetUser();
            ViewBag.users = result;
            return View();
        }
        public async Task<IActionResult> GotoviewWithToken()
        {
            var result = await _userApiService.GotoView();
            ViewBag.message = result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
