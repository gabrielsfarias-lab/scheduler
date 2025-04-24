using Microsoft.EntityFrameworkCore;

namespace Scheduler.Services.Tests
{
    // Inherit from TestBase to get a clean in-memory DbContext for each test
    public class ServiceManagerTests : TestBase
    {
        [Fact] // Marks this method as a test to be run by xUnit
        public async Task AddService_ShouldAddServiceToDatabase()
        {
            // Arrange: Configure the environment and objects needed for the test
            using var context = CreateDbContext(); // Get a fresh in-memory DbContext

            // We need an instance of the service we are testing
            // This line will initially cause a compile error (Red) because ServiceService doesn't exist
            // Let's anticipate its name and how we'll inject the context
            var serviceManager = new ServiceManager(context); // Creating an instance

            // Prepare the data for the service to be added
            var userId = Guid.NewGuid().ToString(); // Dummy User Id for the provider
            var serviceName = "Corte Masculino";
            var serviceDescription = "Corte de cabelo padrao para homens.";
            var serviceDuration = 30; // minutes
            var servicePrice = 50.00m; // decimal price

            // Act: Perform the action being tested
            // We will call a method on the service to add the service
            await serviceManager.AddAsync(userId, serviceName, serviceDescription, serviceDuration, servicePrice); // Using the instance

            // Assert: Check if the action had the expected result
            // We expect the service to be in the database after adding it
            // The test should initially FAIL (Red) because the service and methods don't exist/don't work

            // Check if the database now contains a service with the expected name for the given user
            var addedServiceExists = await context.Services.AnyAsync(s => s.UserId == userId && s.Name == serviceName);

            // We expect that a service with this name and user id was added
            Assert.True(addedServiceExists);

            // Optional: verify other properties if needed in a later test or refactor
            // var addedService = await context.Services.SingleOrDefaultAsync(s => s.UserId == userId && s.Name == serviceName);
            // Assert.NotNull(addedService);
            // Assert.Equal(serviceDescription, addedService.Description);
            // Assert.Equal(serviceDuration, addedService.DurationInMinutes);
            // Assert.Equal(servicePrice, addedService.Price);
        }

        // We will add tests for getting/listing services later
    }
}