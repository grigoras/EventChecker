using EventChecker.Infrastructure.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace EventChecker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Add(User user)
        {
            using var context = new ApiContext();
            return context.Users.Add(user).Entity;
        }

        public List<User> GetAll()
        {
            using var context = new ApiContext();
            var list = context.Users
                .ToList();
            return list;
        }
    }
}
