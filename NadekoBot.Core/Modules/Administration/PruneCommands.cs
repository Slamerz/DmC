﻿using Discord;
using Discord.Commands;
using EvilMortyBot.Extensions;
using System;
using System.Threading.Tasks;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Modules.Administration.Services;

namespace EvilMortyBot.Modules.Administration
{
    public partial class Administration
    {
        [Group]
        public class PruneCommands : EvilMortySubmodule<PruneService>
        {
            private static readonly TimeSpan twoWeeks = TimeSpan.FromDays(14);

            //delets her own messages, no perm required
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            public async Task Prune()
            {
                var user = await Context.Guild.GetCurrentUserAsync().ConfigureAwait(false);

                await _service.PruneWhere((ITextChannel)Context.Channel, 100, (x) => x.Author.Id == user.Id).ConfigureAwait(false);
                Context.Message.DeleteAfter(3);
            }
            // prune x
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(ChannelPermission.ManageMessages)]
            [RequireBotPermission(ChannelPermission.ManageMessages)]
            [Priority(1)]
            public async Task Prune(int count)
            {
                count++;
                if (count < 1)
                    return;
                if (count > 1000)
                    count = 1000;
                await _service.PruneWhere((ITextChannel)Context.Channel, count, x => true).ConfigureAwait(false);
            }

            //prune @user [x]
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(ChannelPermission.ManageMessages)]
            [RequireBotPermission(ChannelPermission.ManageMessages)]
            [Priority(0)]
            public async Task Prune(IGuildUser user, int count = 100)
            {
                if (user.Id == Context.User.Id)
                    count++;

                if (count < 1)
                    return;

                if (count > 1000)
                    count = 1000;
                await _service.PruneWhere((ITextChannel)Context.Channel, count, m => m.Author.Id == user.Id && DateTime.UtcNow - m.CreatedAt < twoWeeks);
            }
        }
    }
}
