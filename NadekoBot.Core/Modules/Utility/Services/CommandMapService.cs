﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using EvilMortyBot.Common.ModuleBehaviors;
using EvilMortyBot.Extensions;
using EvilMortyBot.Core.Services;
using EvilMortyBot.Core.Services.Database.Models;
using NLog;

namespace EvilMortyBot.Modules.Utility.Services
{
    public class CommandMapService : IInputTransformer, INService
    {
        private readonly Logger _log;

        public ConcurrentDictionary<ulong, ConcurrentDictionary<string, string>> AliasMaps { get; } = new ConcurrentDictionary<ulong, ConcurrentDictionary<string, string>>();
        //commandmap
        public CommandMapService(EvilMortyBot bot)
        {
            _log = LogManager.GetCurrentClassLogger();
            AliasMaps = new ConcurrentDictionary<ulong, ConcurrentDictionary<string, string>>(
                bot.AllGuildConfigs.ToDictionary(
                    x => x.GuildId,
                        x => new ConcurrentDictionary<string, string>(x.CommandAliases
                            .Distinct(new CommandAliasEqualityComparer())
                            .ToDictionary(ca => ca.Trigger, ca => ca.Mapping))));
        }

        public async Task<string> TransformInput(IGuild guild, IMessageChannel channel, IUser user, string input)
        {
            await Task.Yield();

            if (guild == null || string.IsNullOrWhiteSpace(input))
                return input;
            
            if (guild != null)
            {
                input = input.ToLowerInvariant();
                if (AliasMaps.TryGetValue(guild.Id, out ConcurrentDictionary<string, string> maps))
                {
                    var keys = maps.Keys
                        .OrderByDescending(x => x.Length);

                    foreach (var k in keys)
                    {
                        string newInput;
                        if (input.StartsWith(k + " "))
                            newInput = maps[k] + input.Substring(k.Length, input.Length - k.Length);
                        else if (input == k)
                            newInput = maps[k];
                        else
                            continue;

                        try
                        {
                            var toDelete = await channel.SendConfirmAsync($"{input} => {newInput}").ConfigureAwait(false);
                            var _ = Task.Run(async () =>
                            {
                                await Task.Delay(1500);
                                await toDelete.DeleteAsync(new RequestOptions() {
                                    RetryMode = RetryMode.AlwaysRetry
                                });
                            });
                        }
                        catch { }
                        return newInput; 
                    }
                }
            }

            return input;
        }
    }

    public class CommandAliasEqualityComparer : IEqualityComparer<CommandAlias>
    {
        public bool Equals(CommandAlias x, CommandAlias y) => x.Trigger == y.Trigger;

        public int GetHashCode(CommandAlias obj) => obj.Trigger.GetHashCode();
    }
}
