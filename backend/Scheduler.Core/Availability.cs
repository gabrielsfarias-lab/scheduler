namespace Scheduler.Core
{
    // Represents a recurring period of availability for a service provider
    // E.g., Monday 9:00 AM to 5:00 PM
    public class Availability
    {
        public Guid Id { get; set; } // Using Guid for Id
        public DayOfWeek DayOfWeek { get; set; } // Day of the week (Monday, Tuesday, etc.)
        public TimeSpan StartTime { get; set; } // Start time of the availability block
        public TimeSpan EndTime { get; set; } // End time of the availability block

        // Foreign Key to the Service Provider (ApplicationUser)
        public string? UserId { get; set; }

        // Navigation property
        public ApplicationUser? User { get; set; }
    }
}
