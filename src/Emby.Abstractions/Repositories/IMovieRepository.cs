using System.Collections.Generic;
using System.Threading.Tasks;
using Devpro.Emby.Abstractions.Models;

namespace Devpro.Emby.Abstractions.Repositories
{
    public interface IMovieRepository
    {
        Task<List<ItemModel>> FindAllAsync(string userId);
    }
}
