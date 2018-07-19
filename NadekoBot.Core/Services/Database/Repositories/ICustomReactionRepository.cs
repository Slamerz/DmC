using System.Collections.Generic;
using EvilMortyBot.Core.Services.Database.Models;

namespace EvilMortyBot.Core.Services.Database.Repositories
{
    public interface ICustomReactionRepository : IRepository<CustomReaction>
    {
        CustomReaction[] GetGlobalAndFor(IEnumerable<long> ids);
        CustomReaction[] For(ulong id);
    }
}
