using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Devpro.Emby.Client.DependencyInjection
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the dependency injection configuration.
        /// </summary>
        /// <typeparam name="T">Instance of <see cref="IEmbyClientConfiguration"/></typeparam>
        /// <param name="services">Collection of services that will be completed</param>
        /// <returns></returns>
        /// <remarks>https://github.com/MediaBrowser/Emby/wiki/Api-Key-Authentication</remarks>
        public static IServiceCollection AddEmbyClient<T>(this IServiceCollection services, T configuration)
            where T : class, IEmbyClientConfiguration
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.TryAddSingleton<IEmbyClientConfiguration>(configuration);
            services.TryAddTransient<Abstractions.Repositories.IMovieRepository, Repositories.MovieRepository>();
            services.TryAddTransient<Abstractions.Repositories.ILibraryRepository, Repositories.LibraryRepository>();

            services
                .AddHttpClient(configuration.HttpClientName, client =>
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Emby-Token", configuration.ApiKey);
                });

            return services;
        }
    }
}
