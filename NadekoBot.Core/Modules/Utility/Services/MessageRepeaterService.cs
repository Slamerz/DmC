﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using EvilMortyBot.Modules.Utility.Common;
using EvilMortyBot.Core.Services;
using EvilMortyBot.Core.Services.Database.Models;

namespace EvilMortyBot.Modules.Utility.Services
{
    public class MessageRepeaterService : INService
    {
        //messagerepeater
        //guildid/RepeatRunners
        public ConcurrentDictionary<ulong, ConcurrentQueue<RepeatRunner>> Repeaters { get; set; }
        public bool RepeaterReady { get; private set; }

        public MessageRepeaterService(EvilMortyBot bot, DiscordSocketClient client)
        {
            var _ = Task.Run(async () =>
            {
                await bot.Ready.Task.ConfigureAwait(false);

                Repeaters = new ConcurrentDictionary<ulong, ConcurrentQueue<RepeatRunner>>(
                    bot.AllGuildConfigs
                        .Select(gc =>
                        {
                            var guild = client.GetGuild(gc.GuildId);
                            if (guild == null)
                                return (0, null);
                            return (gc.GuildId, new ConcurrentQueue<RepeatRunner>(gc.GuildRepeaters
                                .Select(gr => new RepeatRunner(client, guild, gr))
                                .Where(x => x.Guild != null)));
                        })
                        .Where(x => x.Item2 != null)
                        .ToDictionary(x => x.GuildId, x => x.Item2));
                RepeaterReady = true;
            });
        }
    }
}
