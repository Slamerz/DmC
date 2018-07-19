using System.Threading.Tasks;

namespace EvilMortyBot.Modules.Music.Common.SongResolver.Strategies
{
    public interface IResolveStrategy
    {
        Task<SongInfo> ResolveSong(string query);
    }
}
