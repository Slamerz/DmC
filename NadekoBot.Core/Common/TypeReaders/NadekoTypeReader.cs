using Discord.Commands;
using Discord.WebSocket;

namespace EvilMortyBot.Core.Common.TypeReaders
{
    public abstract class EvilMortyTypeReader<T> : TypeReader
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _cmds;

        private EvilMortyTypeReader() { }
        public EvilMortyTypeReader(DiscordSocketClient client, CommandService cmds)
        {
            _client = client;
            _cmds = cmds;
        }
    }
}
