using System;
using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Emby.Abstractions.Repositories;
using Devpro.Emby.Client.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Devpro.Emby.Client.IntegrationTests.Localhost
{
    [Trait("Environment", "Localhost")]
    public class MovieRepositoryLocalhostIntegrationTest : RepositoryIntegrationTestBase<EmbyClientLocalhostConfiguration>
    {
        public MovieRepositoryLocalhostIntegrationTest()
            : base(new EmbyClientLocalhostConfiguration())
        {
        }

        [Fact]
        public async Task PropertyRepositorySandboxFindAllAsync_ReturnToken()
        {
            // Arrange
            var repository = BuildRepository();
            var userId = Configuration.UserId;

            // Act
            var output = await repository.FindAllAsync(userId);

            // Assert
            output.Should().NotBeNullOrEmpty();
        }

        private IMovieRepository BuildRepository()
        {
            var logger = ServiceProvider.GetService<ILogger<MovieRepository>>();
            var httpClientFactory = ServiceProvider.GetService<IHttpClientFactory>();

            return new MovieRepository(Configuration, logger, httpClientFactory);
        }
    }
}
