namespace Scheduler.Core
{
    // Represents a client who books an appointment
    // This is stored for the provider's record, clients do not have login accounts
    public class Client
    {
        public Guid Id { get; set; } // Using Guid for Id
        public string Name { get; set; }
        public string Email { get; set; } // Primary contact method
        public string PhoneNumber { get; set; } // Alternative contact method

        // Navigation property for appointments made by this client
        public ICollection<Appointment> Appointments { get; set; }

        // Optional: Foreign Key to the Service Provider if a client is only managed by one provider
        // public string ServiceProviderUserId { get; set; }
        // public ApplicationUser ServiceProviderUser { get; set; }
        // For simplicity initially, a client can be linked directly via the Appointment entity
    }
}