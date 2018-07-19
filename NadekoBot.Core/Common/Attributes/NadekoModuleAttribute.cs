using System;
using Discord.Commands;

namespace EvilMortyBot.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    sealed class EvilMortyModuleAttribute : GroupAttribute
    {
        public EvilMortyModuleAttribute(string moduleName) : base(moduleName)
        {
        }
    }
}

