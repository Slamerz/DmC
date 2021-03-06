﻿using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace EvilMortyBot.Common
{
    public class NoPublicBot : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
#if GLOBAL_NADEKO
            return Task.FromResult(PreconditionResult.FromError("Not available on the public bot"));
#else
            return Task.FromResult(PreconditionResult.FromSuccess());
#endif
        }
    }
}
