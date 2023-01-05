using Microsoft.AspNetCore.Mvc;
using MVCApp.Models.Db;
using MVCApp.Models.Repositories;
using System;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        ///  Метод, возвращающий страницу с зарегестрированными пользователями
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        /// <summary>
        ///  Метод, возвращающий страницу регистрации
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        /// <summary>
        ///  Метод, возвращающий [Post] страницу регистрации с добавлением пользователя
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }

    }
}
