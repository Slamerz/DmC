using EvilMortyBot.Modules.Music.Common.SongResolver.Strategies;
using EvilMortyBot.Core.Services.Database.Models;
using System.Threading.Tasks;

namespace EvilMortyBot.Modules.Music.Common.SongResolver
{
    public interface ISongResolverFactory
    {
        Task<IResolveStrategy> GetResolveStrategy(string query, MusicType? musicType);
    }
}
