using EvilMortyBot.Core.Common.Pokemon;
using EvilMortyBot.Modules.Games.Common.Trivia;
using System.Collections.Generic;

namespace EvilMortyBot.Core.Services
{
    public interface ILocalDataCache
    {
        IReadOnlyDictionary<string, SearchPokemon> Pokemons { get; }
        IReadOnlyDictionary<string, SearchPokemonAbility> PokemonAbilities { get; }
        TriviaQuestion[] TriviaQuestions { get; }
        IReadOnlyDictionary<int, string> PokemonMap { get; }
    }
}
