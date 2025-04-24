using Microsoft.EntityFrameworkCore;
using Scheduler.Infra; // Importante: Use o namespace do seu projeto Infra

namespace Scheduler.Services.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected ApplicationDbContext CreateDbContext()
        {
            // Use o provedor em memória com um nome de banco de dados único para cada teste
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            var context = new ApplicationDbContext(optionsBuilder.Options);

            // Nota: Migrations nao sao usadas com o provedor em memoria.
            // A estrutura do banco em memoria e construida a partir do modelo do DbContext.

            return context;
        }

        public void Dispose()
        {
            // Nao ha limpeza de arquivo necessaria para o provedor em memoria.
            // Chamar GC.SuppressFinalize(this) como boa pratica em IDisposable.
            GC.SuppressFinalize(this);
        }

        // Note: If you need to clean up the DbContext instance itself
        // within a test method after obtaining it from CreateDbContext(),
        // remember to use a 'using' statement or call .Dispose() explicitly.
        // Example: using var context = CreateDbContext();
    }
}