﻿using System.Threading.Tasks;
using Discord;

namespace EvilMortyBot.Common.ModuleBehaviors
{
    /// <summary>
    /// Implemented by modules which block execution before anything is executed
    /// </summary>
    public interface IEarlyBlocker
    {
        Task<bool> TryBlockEarly(IGuild guild, IUserMessage msg);
    }
}
