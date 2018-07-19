﻿using System;
using System.Collections.Generic;
using EvilMortyBot.Common;
using EvilMortyBot.Extensions;
using EvilMortyBot.Core.Services;

namespace EvilMortyBot.Modules.Games.Common.Trivia
{
    public class TriviaQuestionPool
    {
        private readonly IDataCache _cache;
        private readonly int maxPokemonId;

        private readonly EvilMortyRandom _rng = new EvilMortyRandom();

        private TriviaQuestion[] Pool => _cache.LocalData.TriviaQuestions;
        private IReadOnlyDictionary<int, string> Map => _cache.LocalData.PokemonMap;

        public TriviaQuestionPool(IDataCache cache)
        {
            _cache = cache;
            maxPokemonId = 721; //xd
        }

        public TriviaQuestion GetRandomQuestion(HashSet<TriviaQuestion> exclude, bool isPokemon)
        {
            if (Pool.Length == 0)
                return null;

            if (isPokemon)
            {
                var num = _rng.Next(1, maxPokemonId + 1);
                return new TriviaQuestion("Who's That Pokémon?", 
                    Map[num].ToTitleCase(),
                    "Pokemon",
                    $@"http://evilMortybot.me/images/pokemon/shadows/{num}.png",
                    $@"http://evilMortybot.me/images/pokemon/real/{num}.png");
            }
            TriviaQuestion randomQuestion;
            while (exclude.Contains(randomQuestion = Pool[_rng.Next(0, Pool.Length)])) ;

            return randomQuestion;
        }
    }
}
