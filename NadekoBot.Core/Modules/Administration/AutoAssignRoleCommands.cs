﻿using Discord;
using Discord.Commands;
using EvilMortyBot.Extensions;
using EvilMortyBot.Core.Services;
using System.Linq;
using System.Threading.Tasks;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Modules.Administration.Services;

namespace EvilMortyBot.Modules.Administration
{
    public partial class Administration
    {
        [Group]
        public class AutoAssignRoleCommands : EvilMortySubmodule<AutoAssignRoleService>
        {
            private readonly DbService _db;

            public AutoAssignRoleCommands(DbService db)
            {
                _db = db;
            }

            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(GuildPermission.ManageRoles)]
            public async Task AutoAssignRole([Remainder] IRole role = null)
            {
                var guser = (IGuildUser)Context.User;
                if (role != null)
                    if (Context.User.Id != guser.Guild.OwnerId && guser.GetRoles().Max(x => x.Position) <= role.Position)
                        return;

                if (role == null)
                {
                    _service.DisableAar(Context.Guild.Id);
                    await ReplyConfirmLocalized("aar_disabled").ConfigureAwait(false);
                    return;
                }

                _service.EnableAar(Context.Guild.Id, role.Id);
                await ReplyConfirmLocalized("aar_enabled").ConfigureAwait(false);
            }
        }
    }
}
