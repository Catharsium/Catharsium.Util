using Catharsium.Util.Testing.Databases._Configuration;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Databases
{
    public class DbContextTestFixture<T, TContext> : TestFixture<T> where T : class 
        where TContext : DbContext
    {
        public DbContextTestFixture(
            IServiceCollection serviceCollection = null,
            IDependencyRetriever dependencyRetriever = null,
            IConstructorFilter constructorFilter = null,
            ITargetFactory<T> targetFactory = null)
        {
            var services = ServiceCollectionFactory.Create(serviceCollection ?? new ServiceCollection())
                .AddDatabaseTestingUtilities<TContext>()
                .BuildServiceProvider();
            this.DependencyRetriever = dependencyRetriever ?? services.GetService<IDependencyRetriever>();
            this.ConstructorFilter = constructorFilter ?? services.GetService<IConstructorFilter>();
            this.TargetFactory = targetFactory ?? new TargetFactory<T>(this.ConstructorFilter);
            this.Setup();
        }
    }


    public class DbContextTestFixture<T, TContext1, TContext2> : TestFixture<T>
        where T : class 
        where TContext1 : DbContext 
        where TContext2 : DbContext
    {
        public DbContextTestFixture(
            IServiceCollection serviceCollection = null,
            IDependencyRetriever dependencyRetriever = null,
            IConstructorFilter constructorFilter = null,
            ITargetFactory<T> targetFactory = null)
        {
            var services = ServiceCollectionFactory.Create(serviceCollection ?? new ServiceCollection())
                .AddDatabaseTestingUtilities<TContext1>()
                .AddDatabaseTestingUtilities<TContext2>()
                .BuildServiceProvider();
            this.DependencyRetriever = dependencyRetriever ?? services.GetService<IDependencyRetriever>();
            this.ConstructorFilter = constructorFilter ?? services.GetService<IConstructorFilter>();
            this.TargetFactory = targetFactory ?? new TargetFactory<T>(this.ConstructorFilter);
            this.Setup();
        }
    }
}