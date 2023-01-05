using Microsoft.EntityFrameworkCore;
using MVCApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVCApp.Models.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод, для добавления пользователя в бд
        /// </summary>
        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Метод, для получения всех пользователей из бд
        /// </summary>
        public async Task<User[]> GetUsers()
        {
            // Получим всех активных пользователей
            return await _context.Users.ToArrayAsync();
        }
    }
}
