using GreenTubeTask.Models;
using GreenTubeTask.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext dbContext;

        public UserRepository(ApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetUserByGuid(string guid)
        {
            return dbContext.Users.Include(u => u.Wallet).ThenInclude(w => w.Transactions)
                .FirstOrDefault(u => u.Id == guid);
        }

        public async Task<User> GetUserByGuidAsync(string guid)
        {
            return await dbContext.Users.Include(u => u.Wallet).ThenInclude(w => w.Transactions)
                .FirstOrDefaultAsync(u => u.Id == guid);
        }

        public async Task Register(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            dbContext.Users.Add(user);

            Wallet wallet = new Wallet()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id
            };
            dbContext.Wallets.Add(wallet);

           await dbContext.SaveChangesAsync();
        }

        public async Task<bool> UsernameExists(string username)
        {
            bool exists = await dbContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
            return exists;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await dbContext.Users.ToListAsync();
            return users;
        }
    }
}
