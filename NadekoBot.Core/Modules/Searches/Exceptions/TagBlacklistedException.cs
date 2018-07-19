using System;

namespace EvilMortyBot.Modules.Searches.Exceptions
{
    public class TagBlacklistedException : Exception
    {
        public TagBlacklistedException() : base("Tag you used is blacklisted.")
        {

        }
    }
}
