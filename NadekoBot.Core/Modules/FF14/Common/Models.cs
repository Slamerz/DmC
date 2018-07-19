using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace EvilMortyBot.Modules.FF14.Common
{
    #region Enums

    #endregion

    #region Models

    public partial class Classjob
    {
        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("classjob_parent")]
        public long ClassjobParent { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_job")]
        public long IsJob { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patch")]
        public long Patch { get; set; }
    }
    public partial class PatchClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("patch")]
        public long Patch { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public partial class Paging
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("pages")]
        public List<long> Pages { get; set; }

        [JsonProperty("next")]
        public long Next { get; set; }

        [JsonProperty("prev")]
        public long Prev { get; set; }
    }
    #region Search
    public partial class SearchAchievement
    {
        [JsonProperty("achievement_kind")]
        public long AchievementKind { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("kind_name")]
        public string KindName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("icon_lodestone")]
        public string IconLodestone { get; set; }
    }
    public partial class SearchAction
    {
        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type_name")]
        public string TypeName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchCharacter
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
        public string Server { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }
    }
    public partial class SearchEmote
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("command", NullValueHandling = NullValueHandling.Ignore)]
        public string Command { get; set; }

        [JsonProperty("emote_category", NullValueHandling = NullValueHandling.Ignore)]
        public string EmoteCategory { get; set; }

    }
    public partial class SearchEnemy
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("map_data", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> MapData { get; set; }

        [JsonProperty("map_primary", NullValueHandling = NullValueHandling.Ignore)]
        public object MapPrimary { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType  { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchFate
    {
        [JsonProperty("class_level")]
        public long ClassLevel { get; set; }

        [JsonProperty("class_level_max")]
        public long ClassLevelMax { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("placename")]
        public string Placename { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchGather
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item_level_equip", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemLevelEquip { get; set; }

        [JsonProperty("item_level_item", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemLevelItem { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("level_diff")]
        public long LevelDiff { get; set; }

        [JsonProperty("level_view")]
        public long LevelView { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stars")]
        public long Stars { get; set; }

        [JsonProperty("stars_html")]
        public string StarsHtml { get; set; }

        [JsonProperty("type_name", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("class_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ClassName { get; set; }

        [JsonProperty("icon_lodestone", NullValueHandling = NullValueHandling.Ignore)]
        public string IconLodestone { get; set; }

        [JsonProperty("item_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemName { get; set; }

        [JsonProperty("masterbook")]
        public object Masterbook { get; set; }
    }
    public partial class SearchInstance
    {
        [JsonProperty("content_icon")]
        public object ContentIcon { get; set; }

        [JsonProperty("content_name")]
        public string ContentName { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item_level")]
        public long ItemLevel { get; set; }

        [JsonProperty("item_level_sync")]
        public long ItemLevelSync { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("level_sync")]
        public long LevelSync { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("icon_mini", NullValueHandling = NullValueHandling.Ignore)]
        public string IconMini { get; set; }

        [JsonProperty("icon_lodestone")]
        public string IconLodestone { get; set; }
    }
    public partial class SearchItem
    {
        /// <summary>
        /// Link To Items
        /// </summary>
        [JsonProperty("attributes_params_special")]
        public List<object> AttributesParamsSpecial { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("kind_name")]
        public string KindName { get; set; }

        [JsonProperty("level_equip")]
        public long LevelEquip { get; set; }

        [JsonProperty("level_item")]
        public long LevelItem { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchLeve
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("class_level", NullValueHandling = NullValueHandling.Ignore)]
        public long? ClassLevel { get; set; }

        [JsonProperty("assignment_type_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AssignmentTypeName { get; set; }

    }
    public partial class SearchMinion
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("race", NullValueHandling = NullValueHandling.Ignore)]
        public string Race { get; set; }
    }
    public partial class SearchMount
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("can_fly", NullValueHandling = NullValueHandling.Ignore)]
        public long? CanFly { get; set; }

        [JsonProperty("can_fly_extra", NullValueHandling = NullValueHandling.Ignore)]
        public long? CanFlyExtra { get; set; }
    }
    public partial class SearchNpc
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>
        /// Link to NPCs Maybe??????
        /// </summary>
        [JsonProperty("map_data", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> MapData { get; set; }

        [JsonProperty("map_primary", NullValueHandling = NullValueHandling.Ignore)]
        public object MapPrimary { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchPlace
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
        /// <summary>
        /// Link to Gathering
        /// </summary>
        [JsonProperty("gathering", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Gathering { get; set; }

        [JsonProperty("maps", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Maps { get; set; }
    }
    public partial class SearchQuest
    {
        [JsonProperty("class_1")]
        public string Class1 { get; set; }

        [JsonProperty("class_level_1")]
        public long ClassLevel1 { get; set; }

        [JsonProperty("class_level_2")]
        public long ClassLevel2 { get; set; }

        [JsonProperty("classjob_category_1")]
        public string ClassjobCategory1 { get; set; }

        [JsonProperty("classjob_category_2")]
        public string ClassjobCategory2 { get; set; }

        [JsonProperty("genre_icon")]
        public string GenreIcon { get; set; }

        [JsonProperty("genre_name")]
        public string GenreName { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("items")]
        public string Items { get; set; }

        [JsonProperty("items_total")]
        public long ItemsTotal { get; set; }

        [JsonProperty("journal_genre")]
        public long JournalGenre { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchRecipe
    {
        [JsonProperty("class_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ClassName { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_lodestone")]
        public string IconLodestone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("level_diff")]
        public long LevelDiff { get; set; }

        [JsonProperty("level_view")]
        public long LevelView { get; set; }

        [JsonProperty("masterbook")]
        public object Masterbook { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stars")]
        public long Stars { get; set; }

        [JsonProperty("stars_html")]
        public string StarsHtml { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("item_level_equip", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemLevelEquip { get; set; }

        [JsonProperty("item_level_item", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemLevelItem { get; set; }

        [JsonProperty("type_name", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeName { get; set; }
    }
    public partial class SearchStat
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    public partial class SearchTitle
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }

        [JsonProperty("name_female", NullValueHandling = NullValueHandling.Ignore)]
        public string NameFemale { get; set; }

    }
    public partial class SearchWeather
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_api")]
        public string UrlApi { get; set; }

        [JsonProperty("url_type")]
        public string UrlType { get; set; }

        [JsonProperty("url_xivdb")]
        public string UrlXivdb { get; set; }
    }
    #endregion
    #endregion


   






}
