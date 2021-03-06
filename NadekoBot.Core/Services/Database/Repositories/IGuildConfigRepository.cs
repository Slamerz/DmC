﻿using Microsoft.EntityFrameworkCore;
using EvilMortyBot.Core.Services.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvilMortyBot.Core.Services.Database.Repositories
{
    public interface IGuildConfigRepository : IRepository<GuildConfig>
    {
        GuildConfig For(ulong guildId, Func<DbSet<GuildConfig>, IQueryable<GuildConfig>> includes = null);
        GuildConfig LogSettingsFor(ulong guildId);
        IEnumerable<GuildConfig> GetAllGuildConfigs(List<long> availableGuilds);
        IEnumerable<FollowedStream> GetFollowedStreams(List<long> included);
        IEnumerable<FollowedStream> GetFollowedStreams();
        void SetCleverbotEnabled(ulong id, bool cleverbotEnabled);
        IEnumerable<GuildConfig> Permissionsv2ForAll(List<long> include);
        GuildConfig GcWithPermissionsv2For(ulong guildId);
        XpSettings XpSettingsFor(ulong guildId);
    }
}
