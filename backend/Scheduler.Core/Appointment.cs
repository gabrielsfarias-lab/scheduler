namespace Scheduler.Core
{
    // Represents a confirmed booking
    public class Appointment
    {
        public Guid Id { get; set; } // Using Guid for Id
        public DateTime DateTimeStart { get; set; } // Scheduled start date and time
        public TimeSpan Duration { get; set; } // Duration of the appointment

        public string? ClientNotes { get; set; } // Any notes provided by the client during booking

        // Foreign Key to the Service (what service was booked)
        public Guid ServiceId { get; set; }

        // Navigation property
        public Service? Service { get; set; }

        // Foreign Key to the Client (who booked)
        public Guid ClientId { get; set; }

        // Navigation property
        public Client? Client { get; set; }

        // Foreign Key to the Service Provider (with whom it was booked)
        public string? UserId { get; set; } // Using string as IdentityUser Id is string

        // Navigation property
        public ApplicationUser? User { get; set; } // The Service Provider

        // Optional: Status of the appointment (e.g., Confirmed, Cancelled, Completed)
        // public AppointmentStatus Status { get; set; } // Requires defining an enum

        // Optional: Navigation property back to Client for provider to see all appointments of a client
        // public Client Client { get; set; } // Already have ClientId and Client navigation property
    }

    // Optional: Define an enum for Appointment Status
    // public enum AppointmentStatus
    // {
    //     Confirmed,
    //     Cancelled,
    //     Completed
    // }
}
