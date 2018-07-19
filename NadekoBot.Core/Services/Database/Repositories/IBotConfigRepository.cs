using Microsoft.EntityFrameworkCore;
using EvilMortyBot.Core.Services.Database.Models;
using System;
using System.Linq;

namespace EvilMortyBot.Core.Services.Database.Repositories
{
    public interface IBotConfigRepository : IRepository<BotConfig>
    {
        BotConfig GetOrCreate(Func<DbSet<BotConfig>, IQueryable<BotConfig>> includes = null);
    }
}
