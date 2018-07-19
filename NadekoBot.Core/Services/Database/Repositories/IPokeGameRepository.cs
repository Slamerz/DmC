using EvilMortyBot.Core.Services.Database.Models;

namespace EvilMortyBot.Core.Services.Database.Repositories
{
    public interface IPokeGameRepository : IRepository<UserPokeTypes>
    {
        //List<UserPokeTypes> GetAllPokeTypes();
    }
}
