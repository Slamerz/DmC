﻿using System;
using System.Threading.Tasks;
using Discord.Commands;
using EvilMortyBot.Modules.Administration.Services;
using EvilMortyBot.Core.Common.TypeReaders;
using Discord.WebSocket;

namespace EvilMortyBot.Common.TypeReaders
{
    public class GuildDateTimeTypeReader : EvilMortyTypeReader<GuildDateTime>
    {
        public GuildDateTimeTypeReader(DiscordSocketClient client, CommandService cmds) : base(client, cmds)
        {
        }

        public override Task<TypeReaderResult> ReadAsync(ICommandContext context, string input, IServiceProvider services)
        {
            var _gts = (GuildTimezoneService)services.GetService(typeof(GuildTimezoneService));
            if (!DateTime.TryParse(input, out var dt))
                return Task.FromResult(TypeReaderResult.FromError(CommandError.ParseFailed, "Input string is in an incorrect format."));

            var tz = _gts.GetTimeZoneOrUtc(context.Guild.Id);

            return Task.FromResult(TypeReaderResult.FromSuccess(new GuildDateTime(tz, dt)));
        }
    }

    public class GuildDateTime
    {
        public TimeZoneInfo Timezone { get; }
        public DateTime CurrentGuildTime { get; }
        public DateTime InputTime { get; }
        public DateTime InputTimeUtc { get; }

        private GuildDateTime() { }

        public GuildDateTime(TimeZoneInfo guildTimezone, DateTime inputTime)
        {
            var now = DateTime.UtcNow;
            Timezone = guildTimezone;
            CurrentGuildTime = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.Utc, Timezone);
            InputTime = inputTime;
            InputTimeUtc = TimeZoneInfo.ConvertTime(inputTime, Timezone, TimeZoneInfo.Utc);
        }
    }
}
