﻿using System.Runtime.CompilerServices;
using Discord.Commands;
using EvilMortyBot.Core.Services.Impl;

namespace EvilMortyBot.Common.Attributes
{
    public class Description : SummaryAttribute
    {
        public Description([CallerMemberName] string memberName="") : base(Localization.LoadCommand(memberName.ToLowerInvariant()).Desc)
        {

        }
    }
}
