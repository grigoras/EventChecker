namespace EventChecker.Infrastructure.DbModels
{
    public class User
    {
        public string Email { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
    }
}
