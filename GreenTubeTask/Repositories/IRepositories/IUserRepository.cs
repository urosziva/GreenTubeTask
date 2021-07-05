using GreenTubeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> UsernameExists(string username);
        Task Register(User user);
        User GetUserByGuid(string guid);
        Task<User> GetUserByGuidAsync(string guid);
        Task<List<User>> GetUsers();
    }
}
