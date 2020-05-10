using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Emby.Abstractions.Models;
using Devpro.Emby.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace Devpro.Emby.Client.Repositories
{
    public class MovieRepository : RepositoryBase, IMovieRepository
    {
        public MovieRepository(IEmbyClientConfiguration configuration, ILogger<MovieRepository> logger, IHttpClientFactory httpClientFactory)
            : base(configuration, logger, httpClientFactory)
        {
        }

        public async Task<List<ItemModel>> FindAllAsync(string userId)
        {
            var url = GenerateUrl(resourceName: "Items", suffix: $"?UserId={userId}", arguments: "&Recursive=true&IncludeItemTypes=Movie");
            var output = await GetAsync<ResultModel<ItemModel>>(url);
            return output.Items;
        }
    }
}
