using EvilMortyBot.Core.Modules.Gambling.Common.Blackjack;
using EvilMortyBot.Core.Services;
using System.Collections.Concurrent;

namespace EvilMortyBot.Core.Modules.Gambling.Services
{
    public class BlackJackService : INService
    {
        public ConcurrentDictionary<ulong, Blackjack> Games { get; } = new ConcurrentDictionary<ulong, Blackjack>();
    }
}
