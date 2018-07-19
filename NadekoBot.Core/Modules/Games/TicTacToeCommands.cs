using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading;
using System.Threading.Tasks;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Modules.Games.Services;
using EvilMortyBot.Modules.Games.Common;
using EvilMortyBot.Core.Common;

namespace EvilMortyBot.Modules.Games
{
    public partial class Games
    {
        [Group]
        public class TicTacToeCommands : EvilMortySubmodule<GamesService>
        {
            private readonly SemaphoreSlim _sem = new SemaphoreSlim(1, 1);
            private readonly DiscordSocketClient _client;

            public TicTacToeCommands(DiscordSocketClient client)
            {
                _client = client;
            }

            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [EvilMortyOptions(typeof(TicTacToe.Options))]
            public async Task TicTacToe(params string[] args)
            {
                var (options, _) = OptionsParser.Default.ParseFrom(new TicTacToe.Options(), args);
                var channel = (ITextChannel)Context.Channel;

                await _sem.WaitAsync(1000);
                try
                {
                    if (_service.TicTacToeGames.TryGetValue(channel.Id, out TicTacToe game))
                    {
                        var _ = Task.Run(async () =>
                        {
                            await game.Start((IGuildUser)Context.User);
                        });
                        return;
                    }
                    game = new TicTacToe(base._strings, this._client, channel, (IGuildUser)Context.User, options);
                    _service.TicTacToeGames.Add(channel.Id, game);
                    await ReplyConfirmLocalized("ttt_created").ConfigureAwait(false);

                    game.OnEnded += (g) =>
                    {
                        _service.TicTacToeGames.Remove(channel.Id);
                        _sem.Dispose();
                    };
                }
                finally
                {
                    _sem.Release();
                }
            }
        }
    }
}