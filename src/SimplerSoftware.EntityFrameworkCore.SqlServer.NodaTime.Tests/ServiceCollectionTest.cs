using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplerSoftware.EntityFrameworkCore.SqlServer.NodaTime.Tests.Models;
using Xunit;

namespace SimplerSoftware.EntityFrameworkCore.SqlServer.NodaTime.Tests
{
    public class ServiceCollectionTest
    {
        [Fact]
        public void CustomServiceCollection_ShouldNotThrowError()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .AddNodaTime()
                .BuildServiceProvider(true);

            var builder = new DbContextOptionsBuilder<RacingContext>()
                .UseInternalServiceProvider(serviceProvider)
                .UseSqlServer("Does not matter since we won't try to connect to the DB", opt =>
                {
                    opt.UseNodaTime();
                });

            var dbContext = new RacingContext(builder.Options);
        }
    }
}
