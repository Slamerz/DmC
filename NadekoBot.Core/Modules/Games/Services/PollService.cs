using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using EvilMortyBot.Common.ModuleBehaviors;
using EvilMortyBot.Modules.Games.Common;
using EvilMortyBot.Core.Services;
using EvilMortyBot.Core.Services.Impl;
using NLog;
using EvilMortyBot.Core.Services.Database.Models;
using EvilMortyBot.Common.Collections;
using EvilMortyBot.Extensions;
using EvilMortyBot.Core.Services.Database;

namespace EvilMortyBot.Modules.Games.Services
{
    public class PollService : IEarlyBlockingExecutor, INService
    {
        public ConcurrentDictionary<ulong, PollRunner> ActivePolls { get; } = new ConcurrentDictionary<ulong, PollRunner>();
        private readonly Logger _log;
        private readonly DiscordSocketClient _client;
        private readonly EvilMortyStrings _strings;
        private readonly DbService _db;
        private readonly EvilMortyStrings _strs;

        public PollService(DiscordSocketClient client, EvilMortyStrings strings, DbService db,
            EvilMortyStrings strs, IUnitOfWork uow)
        {
            _log = LogManager.GetCurrentClassLogger();
            _client = client;
            _strings = strings;
            _db = db;
            _strs = strs;

            ActivePolls = uow.Polls.GetAllPolls()
                .ToDictionary(x => x.GuildId, x =>
                {
                    var pr = new PollRunner(db, x);
                    pr.OnVoted += Pr_OnVoted;
                    return pr;
                })
                .ToConcurrent();
        }

        public Poll CreatePoll(ulong guildId, ulong channelId, string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.Contains(";"))
                return null;
            var data = input.Split(';');
            if (data.Length < 3)
                return null;

            var col = new IndexedCollection<PollAnswer>(data.Skip(1)
                .Select(x => new PollAnswer() { Text = x }));

            return new Poll()
            {
                Answers = col,
                Question = data[0],
                ChannelId = channelId,
                GuildId = guildId,
                Votes = new System.Collections.Generic.HashSet<PollVote>()
            };
        }

        public bool StartPoll(Poll p)
        {
            var pr = new PollRunner(_db,  p);
            if (ActivePolls.TryAdd(p.GuildId, pr))
            {
                using (var uow = _db.UnitOfWork)
                {
                    uow.Polls.Add(p);
                    uow.Complete();
                }

                pr.OnVoted += Pr_OnVoted;
                return true;
            }
            return false;
        }

        public Poll StopPoll(ulong guildId)
        {
            if (ActivePolls.TryRemove(guildId, out var pr))
            {
                pr.OnVoted -= Pr_OnVoted;
                using (var uow = _db.UnitOfWork)
                {
                    uow.Polls.RemovePoll(pr.Poll.Id);
                    uow.Complete();
                }
                return pr.Poll;
            }
            return null;
        }

        private async Task Pr_OnVoted(IUserMessage msg, IGuildUser usr)
        {
            var toDelete = await msg.Channel.SendConfirmAsync(_strs.GetText("poll_voted", usr.Guild.Id, "Games".ToLowerInvariant(), Format.Bold(usr.ToString())))
                .ConfigureAwait(false);
            toDelete.DeleteAfter(5);
            try { await msg.DeleteAsync().ConfigureAwait(false); } catch { }
        }

        public async Task<bool> TryExecuteEarly(DiscordSocketClient client, IGuild guild, IUserMessage msg)
        {
            if (guild == null)
                return false;

            if (!ActivePolls.TryGetValue(guild.Id, out var poll))
                return false;

            try
            {
                return await poll.TryVote(msg).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _log.Warn(ex);
            }

            return false;
        }
    }
}
