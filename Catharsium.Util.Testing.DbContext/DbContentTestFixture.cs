using Catharsium.Util.Testing.Databases._Configuration;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Databases
{
    public class DbContentTestFixture<T, TContext> : TestFixture<T> where T : class where TContext : DbContext
    {
        public DbContentTestFixture(
            IServiceCollection serviceCollection = null,
            IDependencyRetriever dependencyRetriever = null,
            IConstructorFilter constructorFilter = null,
            ITargetFactory<T> targetFactory = null)
        {
            var services = ServiceProviderFactory.Create<TContext>(serviceCollection ?? new ServiceCollection());
            this.DependencyRetriever = dependencyRetriever ?? services.GetService<IDependencyRetriever>();
            this.ConstructorFilter = constructorFilter ?? services.GetService<IConstructorFilter>();
            this.TargetFactory = targetFactory ?? new TargetFactory<T>(this.ConstructorFilter);
            this.Setup();
        }
    }
}