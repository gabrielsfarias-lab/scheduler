namespace Scheduler.Core
{
    // Represents a specific time slot that is blocked for a service provider
    // E.g., a personal appointment, lunch break on a specific day
    public class BlockedSlot
    {
        public Guid Id { get; set; } // Using Guid for Id
        public DateTime DateTimeStart { get; set; } // Start date and time of the blocked slot
        public TimeSpan Duration { get; set; } // Duration of the blocked slot

        // Foreign Key to the Service Provider (ApplicationUser)
        public string UserId { get; set; }
        // Navigation property
        public ApplicationUser User { get; set; }
    }
}