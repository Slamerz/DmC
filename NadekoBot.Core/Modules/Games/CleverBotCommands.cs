﻿using Discord;
using Discord.Commands;
using EvilMortyBot.Core.Services;
using System;
using System.Threading.Tasks;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Modules.Games.Services;
using EvilMortyBot.Modules.Games.Common.ChatterBot;

namespace EvilMortyBot.Modules.Games
{
    public partial class Games
    {
        [Group]
        public class ChatterBotCommands : EvilMortySubmodule<ChatterBotService>
        {
            private readonly DbService _db;

            public ChatterBotCommands(DbService db)
            {
                _db = db;
            }

            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(GuildPermission.ManageMessages)]
            public async Task Cleverbot()
            {
                var channel = (ITextChannel)Context.Channel;

                if (_service.ChatterBotGuilds.TryRemove(channel.Guild.Id, out _))
                {
                    using (var uow = _db.UnitOfWork)
                    {
                        uow.GuildConfigs.SetCleverbotEnabled(Context.Guild.Id, false);
                        await uow.CompleteAsync().ConfigureAwait(false);
                    }
                    await ReplyConfirmLocalized("cleverbot_disabled").ConfigureAwait(false);
                    return;
                }

                _service.ChatterBotGuilds.TryAdd(channel.Guild.Id, new Lazy<IChatterBotSession>(() => _service.CreateSession(), true));

                using (var uow = _db.UnitOfWork)
                {
                    uow.GuildConfigs.SetCleverbotEnabled(Context.Guild.Id, true);
                    await uow.CompleteAsync().ConfigureAwait(false);
                }

                await ReplyConfirmLocalized("cleverbot_enabled").ConfigureAwait(false);
            }
        }

       
    }
}