namespace EventChecker.Infrastructure.DbModels
{
    public class Profile
    {
        public long Id { get; set; }
        public ICollection<Cookie> Cookies { get; } = new List<Cookie>();
        public ICollection<User> Users { get; } = new List<User>();
        public ICollection<Visit> Visits { get; } = new List<Visit>();
    }
}
