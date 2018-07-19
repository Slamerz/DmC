using System;

namespace EvilMortyBot.Modules.Searches.Common.Exceptions
{
    public class StreamNotFoundException : Exception
    {
        public StreamNotFoundException(string message) : base($"Stream '{message}' not found.")
        {
        }
    }
}
