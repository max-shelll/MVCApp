using Microsoft.AspNetCore.Mvc;
using MVCApp.Middlewares;
using MVCApp.Models.Db;
using MVCApp.Models.Repositories;
using System;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _repo;

        public RequestController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Logs()
        {
            var logs = await _repo.GetRequests();
            return View(logs);
        }
    }
}
