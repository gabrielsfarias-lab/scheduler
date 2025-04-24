using Scheduler.Core; // Para entidades
using Scheduler.Infra; // Para ApplicationDbContext

namespace Scheduler.Services
{
    public class ServiceManager(ApplicationDbContext context)
    {
        // Minimal implementation to make the test pass
        public async Task AddAsync(
            string userId,
            string name,
            string description,
            int durationInMinutes,
            decimal price
        )
        {
            // Create the Service entity
            var service = new Service
            {
                Id = Guid.NewGuid(), // Generate a new Id (assuming Guid in entity)
                UserId = userId,
                Name = name,
                Description = description,
                DurationInMinutes = durationInMinutes,
                Price = price,
                IsActive = true, // Default to active
            };

            // Add to the context
            context.Services.Add(service);

            // Save changes
            await context.SaveChangesAsync();
        }

        // Methods for getting/listing services will be added with subsequent tests
    }
}
