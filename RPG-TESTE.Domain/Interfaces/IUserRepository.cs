using RPG_TESTE.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> ValidateEmail(string email);
        public Task<User?> CreateUserAsync(User user);
        public Task<bool> UserExistsAsync(string email);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<bool> DeleteUserAsync(int userId);
        public Task<User?> GetUserByIdAsync(int userId);
        public Task<User?> GetUserIdAndProfile(int userId);

    }
}
