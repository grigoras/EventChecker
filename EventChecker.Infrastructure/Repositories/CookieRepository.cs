using EventChecker.Infrastructure.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace EventChecker.Infrastructure.Repositories
{
    public class CookieRepository : ICookieRepository
    {
        public Cookie Add(Cookie cookie)
        {
            using var context = new ApiContext();
            return context.Cookies.Add(cookie).Entity;
        }

        public List<Cookie> GetAll()
        {
            using var context = new ApiContext();
            var list = context.Cookies
                .ToList();
            return list;
        }
    }
}
