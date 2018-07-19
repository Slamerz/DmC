using EvilMortyBot.Common;
using EvilMortyBot.Core.Services.Database.Models;

namespace EvilMortyBot.Core.Services
{
    public interface IBotConfigProvider
    {
        BotConfig BotConfig { get; }
        void Reload();
        bool Edit(BotConfigEditType type, string newValue);
    }
}
