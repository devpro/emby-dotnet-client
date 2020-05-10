namespace Devpro.Emby.Client
{
    public class DefaultEmbyClientConfiguration : IEmbyClientConfiguration
    {
        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }

        public string HttpClientName { get; set; } = "EmbyServerApi";
    }
}
