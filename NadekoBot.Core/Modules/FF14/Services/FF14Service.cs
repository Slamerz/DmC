using Discord;
using Discord.WebSocket;
using EvilMortyBot.Extensions;
using EvilMortyBot.Core.Services;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EvilMortyBot.Modules.Searches.Common;
using EvilMortyBot.Core.Services.Database.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using AngleSharp;
using System.Threading;
using ImageSharp;
using Image = ImageSharp.Image;
using SixLabors.Primitives;
using SixLabors.Fonts;
using EvilMortyBot.Core.Services.Impl;
using EvilMortyBot.Core.Modules.Searches.Common;
using EvilMortyBot.Modules.FF14.Common;
using EvilMortyBot.Modules.FF14.Extensions;

namespace EvilMortyBot.Modules.FF14.Services
{
    public class FF14Service : INService
    {
        public HttpClient Http { get; }
        private readonly DiscordSocketClient _client;
        private readonly DbService _db;
        private readonly Logger _log;
        private readonly IImageCache _imgs;
        private readonly IDataCache _cache;
        private readonly FontProvider _fonts;
        private readonly ConcurrentDictionary<ulong, SearchImageCacher> _imageCacher = new ConcurrentDictionary<ulong, SearchImageCacher>();

        public FF14Service(DiscordSocketClient client,
            DbService db, EvilMortyBot bot, IDataCache cache,
            FontProvider fonts)
        {
            Http = new HttpClient();
            Http.AddFakeHeaders();
            _client = client;
            _db = db;
            _log = LogManager.GetCurrentClassLogger();
            _imgs = cache.LocalImages;
            _cache = cache;
            _fonts = fonts;
        }
        public EmbedBuilder GetAch(Achievements a)
        {
            var e = new EmbedBuilder().WithOkColor().WithAuthor("Mr. Meekupo", "https://vignette.wikia.nocookie.net/monster/images/7/7b/Moogle.png/revision/latest?cb=20130228012509");
            e.WithTitle(a.Name)
                            .WithUrl(a.UrlXivdb)
                            .WithDescription(a.Help)
                            .WithThumbnailUrl(a.Icon)
                            .AddField("Kind", a.KindName, true)
                            .AddField("Category", a.CategoryName, true)
                            .AddField("Points", a.Points.ToString(), true)
                            .AddField("Patch", a.Patch.Name + ": " + a.Patch.Number, false);
            return e;
        }
        public EmbedBuilder GetAct(Actions a)
        {
            var e = new EmbedBuilder().WithOkColor().WithAuthor("Mr. Meekupo", "https://vignette.wikia.nocookie.net/monster/images/7/7b/Moogle.png/revision/latest?cb=20130228012509");
            if (a.IsInGame == 0) e.WithErrorColor().WithFooter("This action is no longer in the game.");
            if (a.ClassName != null)
                e.AddField("Class", a.ClassName, true)
                 .AddField("Level", a.Level.ToString(), true);
            e.WithTitle(a.Name)
                .WithUrl(a.UrlXivdb)
                .WithDescription(a.Help)
                .WithThumbnailUrl(a.Icon)
                .AddField("Skill Type", a.TypeName);
            //Target Info
            if (a.CastRange == -1) e.AddField("Range", "Melee", true);
            else e.AddField("Range", a.CastRange.ToString() + " Yards", true);
            if (a.CastTime == 0) e.AddField("Cast Time", "Instant");
            else e.AddField("Cast Time", a.CastTime.ToString() + " Seconds", true);
            if (a.RecastTime == 0) e.AddField("Cooldown", "No Cooldown");
                else e.AddField("Cooldown", a.RecastTime.ToString() + " Seconds", true);
            string b = "__Dead:__" + a.CanTargetDead.GetCheckMark() + "**|**__Friendly:__" + a.CanTargetFriendly.GetCheckMark() + "**|**__Hostile:__" + a.CanTargetHostile.GetCheckMark() + "**|**__Party Member:__" + a.CanTargetParty.GetCheckMark() + "**|**__Self:__"+ a.CanTargetSelf.GetCheckMark();
            e.AddField("Can Target", b, false);
            return e;
        }
        public EmbedBuilder GetTit(Title a)
        {
            var e = new EmbedBuilder().WithOkColor().WithAuthor("Mr. Meekupo", "https://vignette.wikia.nocookie.net/monster/images/7/7b/Moogle.png/revision/latest?cb=20130228012509");
            string t;
            if (a.Name != a.NameFemale)
                t = "♂️" + a.Name + " | ♀" + a.NameFemale;
            else t = a.Name;
            e.WithTitle(t)
                .WithThumbnailUrl(a.Icon)
                .WithUrl(a.UrlXivdb);
            return e;
        }
        public EmbedBuilder GetChar(Character a)
        {
            var e = new EmbedBuilder().WithOkColor().WithAuthor("Mr. Meekupo", "https://vignette.wikia.nocookie.net/monster/images/7/7b/Moogle.png/revision/latest?cb=20130228012509");


            e.WithTitle(a.Name)
                .WithThumbnailUrl(a.Portrait)
                .WithUrl(a.UrlLodestone)
                .AddField("Server", a.Server, false)
                .AddField("Race", a.Details.Gender.GetGender() + " " + a.Details.Race + ", " + a.Details.Clan, true)
                .AddField("City State", a.Details.City.Name, true);
            string b = null;
            if(a.GrandCompanies.ImmortalFlames != null)
                b += a.GrandCompanies.ImmortalFlames.Name + ": " + a.GrandCompanies.ImmortalFlames.Rank + "/n/r";
            if (a.GrandCompanies.Maelstrom != null)
                b += a.GrandCompanies.Maelstrom.Name + ": " + a.GrandCompanies.Maelstrom.Rank + "/n/r";
            if (a.GrandCompanies.OrderOfTheTwinAdder != null)
                b += a.GrandCompanies.OrderOfTheTwinAdder.Name + ": " + a.GrandCompanies.OrderOfTheTwinAdder.Rank + "/n/r";
            if (b != null)
                e.AddField("Grand Companies", b, false);




            return e;
        }

    }
}
