using Microsoft.EntityFrameworkCore;
using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Infrastructure.Repositories
{
    
    public class UserRepository(AppDbContext appContext) : IUserRepository
    {
        public async Task<User?> CreateUserAsync(User user)
        {
            await appContext.Users.AddAsync(user);
            await appContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> UserExistsAsync(string email)
        {
            return await appContext.Users.AnyAsync(x => x.Email.Equals(email));
        }
        public async Task<User?> ValidateEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
                return null;
            var user = await appContext.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            return user;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await appContext.Users.ToListAsync();
        }
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userToDelete = await appContext.Users.FindAsync(userId);
            if (userToDelete is null)
                return false;
            appContext.Users.Remove(userToDelete);
            await appContext.SaveChangesAsync();
            return true;
        }
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await appContext.Users.FindAsync(userId);
        }
        public async Task<User?> GetUserIdAndProfile(int userId)
        {
            return await appContext.Users
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }


}
