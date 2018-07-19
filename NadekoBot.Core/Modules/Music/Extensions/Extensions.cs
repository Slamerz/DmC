﻿using EvilMortyBot.Modules.Music.Common;
using EvilMortyBot.Core.Services.Database.Models;
using EvilMortyBot.Core.Services.Impl;
using System;
using System.Threading.Tasks;

namespace EvilMortyBot.Modules.Music.Extensions
{
    public static class Extensions
    {
        public static Task<SongInfo> GetSongInfo(this SoundCloudVideo svideo) =>
            Task.FromResult(new SongInfo
            {
                Title = svideo.FullName,
                Provider = "SoundCloud",
                Uri = () => svideo.StreamLink(),
                ProviderType = MusicType.Soundcloud,
                Query = svideo.TrackLink,
                Thumbnail = svideo.artwork_url,
                TotalTime = TimeSpan.FromMilliseconds(svideo.Duration)
            });
    }
}
