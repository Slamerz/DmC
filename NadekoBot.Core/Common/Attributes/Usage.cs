using System.Runtime.CompilerServices;
using Discord.Commands;
using EvilMortyBot.Core.Services.Impl;
using Newtonsoft.Json;

namespace EvilMortyBot.Common.Attributes
{
    public class Usage : RemarksAttribute
    {
        public Usage([CallerMemberName] string memberName="") : base(Usage.GetUsage(memberName))
        {

        }

        public static string GetUsage(string memberName)
        {
            var usage = Localization.LoadCommand(memberName.ToLowerInvariant()).Usage;
            return JsonConvert.SerializeObject(usage);
        }
    }
}
