namespace EventChecker.Infrastructure.DbModels
{
    public class Cookie
    {
        public Guid Id { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
    }
}
