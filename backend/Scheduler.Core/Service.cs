namespace Scheduler.Core
{
    // Represents a service offered by a provider
    public class Service
    {
        public Guid Id { get; set; } // Using Guid for Id
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; } // Duration of the service
        public decimal Price { get; set; } // Price of the service
        public bool IsActive { get; set; } // Is the service currently offered

        // Foreign Key to the Service Provider (ApplicationUser)
        public string UserId { get; set; }
        // Navigation property
        public ApplicationUser User { get; set; }

        // Navigation property for appointments related to this service
        public ICollection<Appointment> Appointments { get; set; }
    }
}