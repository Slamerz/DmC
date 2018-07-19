using System;

namespace EvilMortyBot.Modules.Music.Common.Exceptions
{
    public class NotInVoiceChannelException : Exception
    {
        public NotInVoiceChannelException() : base("You're not in the voice channel on this server.") { }
    }
}
