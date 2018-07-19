using System.Runtime.CompilerServices;
using Discord.Commands;
using EvilMortyBot.Core.Services.Impl;

namespace EvilMortyBot.Common.Attributes
{
    public class EvilMortyCommand : CommandAttribute
    {
        public EvilMortyCommand([CallerMemberName] string memberName="") : base(Localization.LoadCommand(memberName.ToLowerInvariant()).Cmd.Split(' ')[0])
        {

        }
    }
}
