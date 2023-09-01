using EventChecker.Infrastructure.DbModels;
using System.Collections.Generic;

namespace EventChecker.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();

        public User Add(User user);
    }
}
