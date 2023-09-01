using EventChecker.Infrastructure.DbModels;
using System.Collections.Generic;

namespace EventChecker.Infrastructure.Repositories
{
    public interface IVisitRepository
    {
        public List<Visit> GetAll();

        public Visit Add(Visit visit);
    }
}
