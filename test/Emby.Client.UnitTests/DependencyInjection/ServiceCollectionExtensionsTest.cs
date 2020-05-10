using System;
using System.Net.Http;
using Devpro.Emby.Client;
using Devpro.Emby.Client.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Emby.Client.UnitTests.DependencyInjection
{
    [Trait("Category", "UnitTests")]
    public class ServiceCollectionExtensionsTest
    {
        private readonly IEmbyClientConfiguration _configuration;

        public ServiceCollectionExtensionsTest()
        {
            _configuration = new DefaultEmbyClientConfiguration
            {
                BaseUrl = "https://should.not.exist",
                ApiKey = "FakeKey"
            };
        }

        [Fact]
        public void AddEmbyClient_ShouldProvideConfiguration()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();

            // Act
            serviceCollection.AddEmbyClient(_configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            services.GetRequiredService<IEmbyClientConfiguration>().Should().Be(_configuration);
        }

        [Fact]
        public void AddEmbyClient_ShouldProvideRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();

            // Act
            serviceCollection.AddEmbyClient(_configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            services.GetRequiredService<Devpro.Emby.Abstractions.Repositories.ILibraryRepository>().Should().NotBeNull();
            services.GetRequiredService<Devpro.Emby.Abstractions.Repositories.IMovieRepository>().Should().NotBeNull();
        }

        [Fact]
        public void AddEmbyClient_ShouldProvideHttpClient()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();

            // Act
            serviceCollection.AddEmbyClient(_configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
            httpClientFactory.Should().NotBeNull();
            var client = httpClientFactory.CreateClient(_configuration.HttpClientName);
            client.Should().NotBeNull();
        }

        [Fact]
        public void AddEmbyClient_ShouldThrowExceptionIfServiceCollectionIsNull()
        {
            // Arrange
            var serviceCollection = (ServiceCollection)null;

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => serviceCollection.AddEmbyClient(_configuration));

            // Assert
            exc.Should().NotBeNull();
            exc.Message.Should().Be("Value cannot be null. (Parameter 'services')");
        }

        [Fact]
        public void AddEmbyClient_ShouldThrowExceptionIfConfigurationIsNull()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var configuration = (IEmbyClientConfiguration)null;

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => serviceCollection.AddEmbyClient(configuration));

            // Assert
            exc.Should().NotBeNull();
            exc.Message.Should().Be("Value cannot be null. (Parameter 'configuration')");
        }
    }
}
