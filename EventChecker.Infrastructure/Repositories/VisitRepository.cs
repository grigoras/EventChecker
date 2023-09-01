using EventChecker.Infrastructure.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace EventChecker.Infrastructure.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        public Visit Add(Visit visit)
        {
            using var context = new ApiContext();
            return context.Visits.Add(visit).Entity;
        }

        public List<Visit> GetAll()
        {
            using var context = new ApiContext();
            var list = context.Visits
                .ToList();
            return list;
        }
    }
}
