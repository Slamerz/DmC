using System.Linq;
using System.Runtime.CompilerServices;
using Discord.Commands;
using EvilMortyBot.Core.Services.Impl;
namespace EvilMortyBot.Common.Attributes
{
    public class Aliases : AliasAttribute
    {
        public Aliases([CallerMemberName] string memberName = "") : base(Localization.LoadCommand(memberName.ToLowerInvariant()).Cmd.Split(' ').Skip(1).ToArray())
        {
        }
    }
}
