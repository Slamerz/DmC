﻿using System;

namespace EvilMortyBot.Modules.Music.Common.Exceptions
{
    public class SongNotFoundException : Exception
    {
        public SongNotFoundException(string message) : base(message)
        {
        }
        public SongNotFoundException() : base("Song is not found.") { }
    }
}
