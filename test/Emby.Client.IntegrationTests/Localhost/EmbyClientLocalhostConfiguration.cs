using System;

namespace Devpro.Emby.Client.IntegrationTests.Localhost
{
    public class EmbyClientLocalhostConfiguration : IEmbyClientConfiguration
    {
        public string BaseUrl => Environment.GetEnvironmentVariable("Emby__Localhost__BaseUrl") ?? "http://localhost:8096/emby";

        public string ApiKey => Environment.GetEnvironmentVariable("Emby__Localhost__ApiKey");

        public string HttpClientName => "EmbyServerApi";

        public string UserId => Environment.GetEnvironmentVariable("Emby__User__Id");
    }
}
