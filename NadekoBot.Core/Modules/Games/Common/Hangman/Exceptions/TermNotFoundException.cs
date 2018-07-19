using System;

namespace EvilMortyBot.Modules.Games.Common.Hangman.Exceptions
{
    public class TermNotFoundException : Exception
    {
        public TermNotFoundException() : base("Term of that type couldn't be found")
        {
        }
    }
}
