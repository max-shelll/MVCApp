using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApp.Models;
using MVCApp.Models.Db;
using MVCApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        ///  Метод, возвращающий домашнюю страницу
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        ///  Метод, возвращающий страницу конфиденциальности
        /// </summary>
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
