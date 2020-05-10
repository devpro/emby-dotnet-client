using Devpro.Emby.Client.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Devpro.Emby.Client.IntegrationTests
{
    public class RepositoryIntegrationTestBase<T> where T : class, IEmbyClientConfiguration
    {
        protected RepositoryIntegrationTestBase(T configuration)
        {
            Configuration = configuration;

            var services = new ServiceCollection()
                .AddLogging()
                .AddEmbyClient(Configuration);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected ServiceProvider ServiceProvider { get; private set; }

        protected T Configuration { get; private set; }
    }
}
