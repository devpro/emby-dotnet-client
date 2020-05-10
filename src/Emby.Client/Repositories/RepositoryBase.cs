using System.Net.Http;
using Microsoft.Extensions.Logging;
using Withywoods.Net.Http;

namespace Devpro.Emby.Client.Repositories
{
    public abstract class RepositoryBase : HttpRepositoryBase
    {
        protected RepositoryBase(
            IEmbyClientConfiguration configuration,
            ILogger logger,
            IHttpClientFactory httpClientFactory)
            : base(logger, httpClientFactory)
        {
            Configuration = configuration;
        }

        protected IEmbyClientConfiguration Configuration { get; private set; }

        protected override string HttpClientName => Configuration.HttpClientName;

        protected string GenerateUrl(string prefix = "", string resourceName = "", string suffix = "", string arguments = "")
        {
            return $"{Configuration.BaseUrl}{prefix}/{resourceName}{suffix}{arguments}";
        }
    }
}
