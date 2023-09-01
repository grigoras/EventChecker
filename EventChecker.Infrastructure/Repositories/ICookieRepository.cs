using EventChecker.Infrastructure.DbModels;
using System.Collections.Generic;

namespace EventChecker.Infrastructure.Repositories
{
    public interface ICookieRepository
    {
        public List<Cookie> GetAll();

        public Cookie Add(Cookie cookie);
    }
}
