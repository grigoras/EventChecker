using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventChecker.Domain.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public Guid CookieId { get; set; }
        public Guid VisitId { get; set; }
        public string Email { get; set; }
    }
}
