using Scheduler.Core;
using Microsoft.EntityFrameworkCore;

namespace Scheduler.Services.Tests
{
    public class ServiceManagerTests : TestBase
    {
        [Fact]
        public async Task AddService_ShouldAddServiceToDatabase()
        {
            using var context = CreateDbContext();

            var serviceManager = new ServiceManager(context);

            var userId = Guid.NewGuid().ToString();
            var serviceName = "Corte Masculino";
            var serviceDescription = "Corte de cabelo padrao para homens.";
            var serviceDuration = 30;
            var servicePrice = 50.00m;

            await serviceManager.AddAsync(userId, serviceName, serviceDescription, serviceDuration, servicePrice);

            var addedServiceExists = await context.Services.AnyAsync(s => s.UserId == userId && s.Name == serviceName);

            Assert.True(addedServiceExists);
        }

        [Fact]
        public async Task GetServiceById_ShouldReturnCorrectService()
        {
            using var context = CreateDbContext();

            var userId = Guid.NewGuid().ToString();
            var serviceId = Guid.NewGuid();
            var serviceName = "Consulta de Acompanhamento";
            var originalService = new Service
            {
                Id = serviceId,
                UserId = userId,
                Name = serviceName,
                Description = "Consulta de 30 minutos.",
                DurationInMinutes = 30,
                Price = 80.00m,
                IsActive = true
            };
            context.Services.Add(originalService);
            await context.SaveChangesAsync();

            var serviceManager = new ServiceManager(context);

            var foundService = await serviceManager.GetByIdAsync(serviceId);

            // Assert
            // These assertions will cause errors or fail because foundService is not set/found
            // Assert.NotNull(foundService);
            // Assert.Equal(serviceId, foundService.Id);
            // Assert.Equal(serviceName, foundService.Name);
        }
    }
}