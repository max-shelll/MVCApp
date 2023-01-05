using Microsoft.EntityFrameworkCore;
using MVCApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVCApp.Models.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод, для добавления запроса в бд
        /// </summary>
        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Метод, для получения всех запросов из бд
        /// </summary>
        public async Task<Request[]> GetRequests()
        {
            // Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
