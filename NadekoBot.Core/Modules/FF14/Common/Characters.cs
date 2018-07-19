using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text;

namespace EvilMortyBot.Modules.FF14.Common
{
    public partial class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
       
        [JsonProperty("data")]
        public CharData Details { get; set; }

        [JsonProperty("grand_companies")]
        public GrandCompanies GrandCompanies { get; set; }

        [JsonProperty("portrait")]
        public string Portrait { get; set; }

        [JsonProperty("last_active")]
        public DateTimeOffset LastActive { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("url_lodestone")]
        public string UrlLodestone { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("extras")]
        public Extras Extras { get; set; }
    }



    public partial class CharData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("portrait")]
        public string Portrait { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("clan")]
        public string Clan { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("nameday")]
        public string Nameday { get; set; }

        [JsonProperty("guardian")]
        public City Guardian { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("grand_company")]
        public GrandCompany GrandCompany { get; set; }

        [JsonProperty("classjobs")]
        public Dictionary<string, ClassProgress> Classjobs { get; set; }

        [JsonProperty("mounts")]
        public Dictionary<string, Minion> Mounts { get; set; }

        [JsonProperty("minions")]
        public Dictionary<string, Minion> Minions { get; set; }

        [JsonProperty("active_class")]
        public ActiveClass ActiveClass { get; set; }
    }

    public partial class City
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public partial class GrandCompany
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }
    }
    public partial class ClassProgress
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("exp")]
        public Exp Exp { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("data")]
        public Role Data { get; set; }

        [JsonProperty("level_togo")]
        public long LevelTogo { get; set; }

        [JsonProperty("level_percent")]
        public double LevelPercent { get; set; }
    }

    public partial class Exp
    {
        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("at_cap")]
        public bool AtCap { get; set; }

        [JsonProperty("total_gained")]
        public long TotalGained { get; set; }

        [JsonProperty("total_max")]
        public long TotalMax { get; set; }

        [JsonProperty("total_togo")]
        public long TotalTogo { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("total_percent")]
        public double TotalPercent { get; set; }
    }
    public partial class Role
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("is_job")]
        public long IsJob { get; set; }

        [JsonProperty("classjob_parent")]
        public long ClassjobParent { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("patch")]
        public long Patch { get; set; }
    }
    public partial class Minion
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("obtained")]
        public Obtained Obtained { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public partial class ActiveClass
    {
        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("progress")]
        public ClassProgress Progress { get; set; }
    }

    public partial struct Obtained
    {
        public bool? Bool;
        public long? Integer;

        public bool IsNull => Bool == null && Integer == null;
    }


    public partial class GrandCompanies
    {
        [JsonProperty("order_of_the_twin_adder", NullValueHandling = NullValueHandling.Ignore)]
        public GrandCompany OrderOfTheTwinAdder { get; set; }
        [JsonProperty("maelstrom", NullValueHandling = NullValueHandling.Ignore)]
        public GrandCompany Maelstrom { get; set; }
        [JsonProperty("immortal_flames", NullValueHandling = NullValueHandling.Ignore)]
        public GrandCompany ImmortalFlames { get; set; }
    }

    public partial class Extras
    {
        [JsonProperty("mounts", NullValueHandling = NullValueHandling.Ignore)]
        public Minions Mounts { get; set; }

        [JsonProperty("minions", NullValueHandling = NullValueHandling.Ignore)]
        public Minions Minions { get; set; }
    }
    public partial class Minions
    {
        [JsonProperty("obtained", NullValueHandling = NullValueHandling.Ignore)]
        public long? Obtained { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("percent", NullValueHandling = NullValueHandling.Ignore)]
        public double? Percent { get; set; }
    }
}
