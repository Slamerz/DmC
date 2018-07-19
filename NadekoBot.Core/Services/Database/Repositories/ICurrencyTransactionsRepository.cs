using System.Collections.Generic;
using EvilMortyBot.Core.Services.Database.Models;

namespace EvilMortyBot.Core.Services.Database.Repositories
{
    public interface ICurrencyTransactionsRepository : IRepository<CurrencyTransaction>
    {
        List<CurrencyTransaction> GetPageFor(ulong userId, int page);
    }
}
