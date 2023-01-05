using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using MVCApp.Models.Db;
using MVCApp.Models.Repositories;
using System.Security.Policy;

namespace MVCApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Метод логирования данных о запросе
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository _repo)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            var newRequest = new Request()
            {
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await _repo.AddRequest(newRequest);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
