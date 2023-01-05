using System;

namespace MVCApp.Models.Db
{
    /// <summary>
    /// модель пользователя в блоге
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
