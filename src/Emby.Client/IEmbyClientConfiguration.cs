﻿namespace Devpro.Emby.Client
{
    /// <summary>
    /// Client library configuration.
    /// It's up to the application that uses this library to decide where to store and read the configuration values.
    /// </summary>
    public interface IEmbyClientConfiguration
    {
        /// <summary>
        /// Emby base URL.
        /// </summary>
        public string BaseUrl { get; }

        /// <summary>
        /// Emby API Key.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// HTTP client name, this is a pure technical name, free text only used internally in the application.
        /// Make sure it's unique to prevent any conflict with another HTTP Client.
        /// </summary>
        public string HttpClientName { get; }
    }
}
