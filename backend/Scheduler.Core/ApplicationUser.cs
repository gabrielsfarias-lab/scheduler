using Microsoft.AspNetCore.Identity;

namespace Scheduler.Core
{
    // Represents the Service Provider who uses the scheduling system
    public class ApplicationUser : IdentityUser
    {
        // Add properties specific to the Service Provider if needed
        // For example:
        // public string BusinessName { get; set; }
        // public string ContactPhone { get; set; }

        // Navigation properties for entities owned by this provider
        public ICollection<Service>? Services { get; set; }
        public ICollection<Availability>? Availability { get; set; }
        public ICollection<BlockedSlot>? BlockedSlots { get; set; }
        public ICollection<Appointment>? Appointments { get; set; } // Appointments where this user is the provider
    }
}
