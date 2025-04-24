using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scheduler.Core;

namespace Scheduler.Infra
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        // DbSet for core scheduling entities
        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<BlockedSlot> BlockedSlots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call the base method to configure Identity tables first
            base.OnModelCreating(builder);

            // Configure relationships using the Fluent API
            // Configure the relationship between Service and ApplicationUser (Provider)
            builder
                .Entity<Service>()
                .HasOne(s => s.User) // A Service has one User (Provider)
                .WithMany(u => u.Services) // A User (Provider) has many Services
                .HasForeignKey(s => s.UserId); // The foreign key is UserId in Service

            // Configure the relationship between Availability and ApplicationUser (Provider)
            builder
                .Entity<Availability>()
                .HasOne(a => a.User)
                .WithMany(u => u.Availability)
                .HasForeignKey(a => a.UserId);

            // Configure the relationship between BlockedSlot and ApplicationUser (Provider)
            builder
                .Entity<BlockedSlot>()
                .HasOne(bs => bs.User)
                .WithMany(u => u.BlockedSlots)
                .HasForeignKey(bs => bs.UserId);

            // Configure the relationship between Appointment and Service
            builder
                .Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId);

            // Configure the relationship between Appointment and Client
            builder
                .Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClientId);

            // Configure the relationship between Appointment and ApplicationUser (Provider)
            builder
                .Entity<Appointment>()
                .HasOne(a => a.User) // An Appointment has one User (Provider)
                .WithMany(u => u.Appointments) // A User (Provider) has many Appointments they are scheduled with
                .HasForeignKey(a => a.UserId);
        }
    }
}
