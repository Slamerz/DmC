using Discord;
using Discord.Commands;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Core.Services;
using System.Threading.Tasks;

namespace EvilMortyBot.Modules.Xp
{
    public partial class Xp
    {
        public class ResetCommands : EvilMortySubmodule
        {
            private readonly DbService _db;

            public ResetCommands(DbService db)
            {
                _db = db;
            }

            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(GuildPermission.Administrator)]
            public Task XpReset(IGuildUser user)
                => XpReset(user.Id);

            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(GuildPermission.Administrator)]
            public async Task XpReset(ulong id)
            {
                var embed = new EmbedBuilder()
                    .WithTitle(GetText("reset"))
                    .WithDescription(GetText("reset_user_confirm"));

                if (!await PromptUserConfirmAsync(embed))
                    return;
                using (var uow = _db.UnitOfWork)
                {
                    uow.Xp.ResetGuildUserXp(id, Context.Guild.Id);
                    uow.Complete();
                }

                await ReplyConfirmLocalized("reset_user", id).ConfigureAwait(false);
            }

            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            [RequireUserPermission(GuildPermission.Administrator)]
            public async Task XpReset()
            {
                var embed = new EmbedBuilder()
                       .WithTitle(GetText("reset"))
                       .WithDescription(GetText("reset_server_confirm"));

                if (!await PromptUserConfirmAsync(embed))
                    return;

                using (var uow = _db.UnitOfWork)
                {
                    uow.Xp.ResetGuildXp(Context.Guild.Id);
                    uow.Complete();
                }

                await ReplyConfirmLocalized("reset_server").ConfigureAwait(false);
            }
        }
    }
}
