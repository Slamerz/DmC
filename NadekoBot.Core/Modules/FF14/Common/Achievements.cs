using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text;

namespace EvilMortyBot.Modules.FF14.Common
{
    //    var questsJson809 = QuestsJson809.FromJson(jsonString);
    public partial class Achievements
    {
        public static Achievements FromJson(string json) => JsonConvert.DeserializeObject<Achievements>(json, AchConverter.Settings);
        [JsonProperty("achievement_category")]
        public long AchievementCategory { get; set; }

        [JsonProperty("achievement_kind")]
        public long AchievementKind { get; set; }

        [JsonProperty("category_id")]
        public long? CategoryId { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("connect_post")]
        public long ConnectPost { get; set; }

        [JsonProperty("connect_pre")]
        public long ConnectPre { get; set; }

        [JsonProperty("connect_quest")]
        public long ConnectQuest { get; set; }

        [JsonProperty("help")]
        public string Help { get; set; }

        [JsonProperty("help_cns")]
        public string HelpCns { get; set; }

        [JsonProperty("help_de")]
        public string HelpDe { get; set; }

        [JsonProperty("help_en")]
        public string HelpEn { get; set; }

        [JsonProperty("help_fr")]
        public string HelpFr { get; set; }

        [JsonProperty("help_ja")]
        public string HelpJa { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_hq")]
        public string IconHq { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("kind_id")]
        public long? KindId { get; set; }

        [JsonProperty("kind_name")]
        public string KindName { get; set; }

        [JsonProperty("lodestone_id")]
        public string LodestoneId { get; set; }

        [JsonProperty("lodestone_type")]
        public string LodestoneType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_cns")]
        public string NameCns { get; set; }

        [JsonProperty("name_de")]
        public string NameDe { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("name_fr")]
        public string NameFr { get; set; }

        [JsonProperty("name_ja")]
        public string NameJa { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("patch")]
        public PatchClass Patch { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("post_achievements")]
        public List<Achievement> PostAchievements { get; set; }

        [JsonProperty("pre_achievements")]
        public List<Achievement> PreAchievements { get; set; }

        [JsonProperty("pre_quests")]
        public List<Requirement> PreQuests { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("requirement_1")]
        public long Requirement1 { get; set; }

        [JsonProperty("requirement_2")]
        public long Requirement2 { get; set; }

        [JsonProperty("requirement_3")]
        public long Requirement3 { get; set; }

        [JsonProperty("requirement_4")]
        public long Requirement4 { get; set; }

        [JsonProperty("requirement_5")]
        public long Requirement5 { get; set; }

        [JsonProperty("requirement_6")]
        public long Requirement6 { get; set; }

        [JsonProperty("requirement_7")]
        public long Requirement7 { get; set; }

        [JsonProperty("requirement_8")]
        public long Requirement8 { get; set; }

        [JsonProperty("requirement_9")]
        public long Requirement9 { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("type")]
        public long PuneHedgehogType { get; set; }

        [JsonProperty("type_name")]
        public string TypeName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_lodestone")]
        public string UrlLodestone { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("url_xivdb_de")]
        public string UrlXivdbDe { get; set; }

        [JsonProperty("url_xivdb_fr")]
        public string UrlXivdbFr { get; set; }

        [JsonProperty("url_xivdb_ja")]
        public string UrlXivdbJa { get; set; }

        [JsonProperty("_cid")]
        public long Cid { get; set; }

        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("requirements", NullValueHandling = NullValueHandling.Ignore)]
        public List<Requirement> Requirements { get; set; }

        [JsonProperty("icon_lodestone")]
        public string IconLodestone { get; set; }
    }

    public partial class Achievement
    {
        [JsonProperty("category_id")]
        public long CategoryId { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("help")]
        public string Help { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_hq")]
        public string IconHq { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("kind_id")]
        public long KindId { get; set; }

        [JsonProperty("kind_name")]
        public string KindName { get; set; }

        [JsonProperty("lodestone_id")]
        public string LodestoneId { get; set; }

        [JsonProperty("lodestone_type")]
        public string LodestoneType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patch")]
        public PatchClass Patch { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_lodestone")]
        public string UrlLodestone { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("url_xivdb_de")]
        public string UrlXivdbDe { get; set; }

        [JsonProperty("url_xivdb_fr")]
        public string UrlXivdbFr { get; set; }

        [JsonProperty("url_xivdb_ja")]
        public string UrlXivdbJa { get; set; }

        [JsonProperty("icon_lodestone")]
        public object IconLodestone { get; set; }
    }

    public partial class Requirement
    {
        [JsonProperty("beast_tribe_name")]
        public object BeastTribeName { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("class_category_1")]
        public string ClassCategory1 { get; set; }

        [JsonProperty("class_category_2")]
        public string ClassCategory2 { get; set; }

        [JsonProperty("class_level_1")]
        public long ClassLevel1 { get; set; }

        [JsonProperty("class_level_2")]
        public long ClassLevel2 { get; set; }

        [JsonProperty("class_name_1")]
        public string ClassName1 { get; set; }

        [JsonProperty("class_name_2")]
        public string ClassName2 { get; set; }

        [JsonProperty("classjob_category_1")]
        public object ClassjobCategory1 { get; set; }

        [JsonProperty("classjob_category_2")]
        public object ClassjobCategory2 { get; set; }

        [JsonProperty("exp_reward")]
        public long ExpReward { get; set; }

        [JsonProperty("genre")]
        public long Genre { get; set; }

        [JsonProperty("genre_icon")]
        public long GenreIcon { get; set; }

        [JsonProperty("genre_name")]
        public string GenreName { get; set; }

        [JsonProperty("header_special")]
        public long HeaderSpecial { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_hq")]
        public string IconHq { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("lodestone_id")]
        public string LodestoneId { get; set; }

        [JsonProperty("lodestone_type")]
        public string LodestoneType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("npc_end")]
        public object NpcEnd { get; set; }

        [JsonProperty("npc_id")]
        public long NpcId { get; set; }

        [JsonProperty("npc_name")]
        public string NpcName { get; set; }

        [JsonProperty("npc_start")]
        public object NpcStart { get; set; }

        [JsonProperty("npc_url")]
        public string NpcUrl { get; set; }

        [JsonProperty("patch")]
        public PatchClass Patch { get; set; }

        [JsonProperty("placename")]
        public string Placename { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_lodestone")]
        public string UrlLodestone { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("url_xivdb_de")]
        public string UrlXivdbDe { get; set; }

        [JsonProperty("url_xivdb_fr")]
        public string UrlXivdbFr { get; set; }

        [JsonProperty("url_xivdb_ja")]
        public string UrlXivdbJa { get; set; }
    }

    public partial class Title
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_hq")]
        public string IconHq { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_female")]
        public string NameFemale { get; set; }

        [JsonProperty("patch")]
        public bool Patch { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("url_xivdb_de")]
        public string UrlXivdbDe { get; set; }

        [JsonProperty("url_xivdb_fr")]
        public string UrlXivdbFr { get; set; }

        [JsonProperty("url_xivdb_ja")]
        public string UrlXivdbJa { get; set; }

        [JsonProperty("icon_lodestone")]
        public string IconLodestone { get; set; }
    }

   

    internal static class AchConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }


   

}
