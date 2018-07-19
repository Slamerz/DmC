using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text;

namespace EvilMortyBot.Modules.FF14.Common
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
    //
    //    using QuickType;
    //  var res = SearchJson.FromJson(string);
    //    var jsonT90 = JsonT90.FromJson(jsonString);

    #region Models Inner
    public partial class Search
    {

        [JsonProperty("items")]
        public SearchItems Items { get; set; }

        [JsonProperty("recipes")]
        public SearchRecipes Recipes { get; set; }

        [JsonProperty("quests")]
        public SearchQuests Quests { get; set; }

        [JsonProperty("actions")]
        public SearchActions Actions { get; set; }

        [JsonProperty("instances")]
        public SearchInstances Instances { get; set; }

        [JsonProperty("achievements")]
        public SearchAchievements Achievements { get; set; }

        [JsonProperty("fates")]
        public SearchFates Fates { get; set; }

        [JsonProperty("leves")]
        public SearchLeves Leves { get; set; }

        [JsonProperty("places")]
        public SearchPlaces Places { get; set; }

        [JsonProperty("gathering")]
        public SearchGathering Gathering { get; set; }

        [JsonProperty("npcs")]
        public SearchNpcs Npcs { get; set; }

        [JsonProperty("enemies")]
        public SearchEnemies Enemies { get; set; }

        [JsonProperty("emotes")]
        public SearchEmotes Emotes { get; set; }

        [JsonProperty("status")]
        public SearchStatus Status { get; set; }

        [JsonProperty("titles")]
        public SearchTitles Titles { get; set; }

        [JsonProperty("minions")]
        public SearchMinions Minions { get; set; }

        [JsonProperty("mounts")]
        public SearchMounts Mounts { get; set; }

        [JsonProperty("weather")]
        public SearchWeathers Weather { get; set; }

        [JsonProperty("characters")]
        public SearchCharacters Characters { get; set; }
    }



    #endregion
    #region Models Base

    public partial class SearchCharacters
    {
        [JsonProperty("results")]
        public List<SearchCharacter> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    
    public partial class SearchWeathers
    {
        [JsonProperty("results")]
        public List<SearchWeather> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    
    public partial class SearchTitles
    {
        [JsonProperty("results")]
        public List<SearchTitle> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    public partial class SearchMounts
    {
        [JsonProperty("results")]
        public List<SearchMount> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    
    public partial class SearchMinions
    {
        [JsonProperty("results")]
        public List<SearchMinion> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchGathering
    {
        [JsonProperty("results")]
        public List<SearchGather> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchStatus
    {
        [JsonProperty("results")]
        public List<SearchStat> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchEnemies
    {
        [JsonProperty("results")]
        public List<SearchEnemy> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    
    public partial class SearchNpcs
    {
        [JsonProperty("results")]
        public List<SearchNpc> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    
    public partial class SearchEmotes
    {
        [JsonProperty("results")]
        public List<SearchEmote> Results { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    
    public partial class SearchLeves
    {
        [JsonProperty("results")]
        public List<SearchLeve> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchPlaces
    {
        [JsonProperty("results")]
        public List<SearchPlace> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchActions
    {
        [JsonProperty("results")]
        public List<SearchAction> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    public partial class SearchItems
    {
        [JsonProperty("results")]
        public List<SearchItem> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    public partial class SearchRecipes
    {
        [JsonProperty("results")]
        public List<SearchRecipe> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchAchievements
    {
        [JsonProperty("results")]
        public List<SearchAchievement> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }



    public partial class SearchFates
    {
        [JsonProperty("results")]
        public List<SearchFate> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchInstances
    {
        [JsonProperty("results")]
        public List<SearchInstance> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class SearchQuests
    {
        [JsonProperty("results")]
        public List<SearchQuest> Results { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    #endregion
   






}
