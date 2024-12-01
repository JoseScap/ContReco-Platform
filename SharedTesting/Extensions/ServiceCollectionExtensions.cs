using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SharedTesting.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryDbContext<T>(this IServiceCollection serviceCollection) where T : DbContext
    {
        serviceCollection.AddDbContext<T>(
            options => options.UseInMemoryDatabase($"{Guid.NewGuid().ToString()}"));
        return serviceCollection;
    }
}
