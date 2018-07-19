using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text;

namespace EvilMortyBot.Modules.FF14.Common
{
    public partial class Item
    {
        [JsonProperty("attributes_base")]
        public Dictionary<string, double> AttributesBase { get; set; }

        [JsonProperty("attributes_params")]
        public List<AttributesParam> AttributesParams { get; set; }

        [JsonProperty("attributes_params_special")]
        public List<object> AttributesParamsSpecial { get; set; }

        [JsonProperty("bonus_name")]
        public string BonusName { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("classjob_category")]
        public string ClassjobCategory { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("connect_achievement")]
        public long ConnectAchievement { get; set; }

        [JsonProperty("connect_craftable")]
        public long ConnectCraftable { get; set; }

        [JsonProperty("connect_enemy_drop")]
        public long ConnectEnemyDrop { get; set; }

        [JsonProperty("connect_gathering")]
        public long ConnectGathering { get; set; }

        [JsonProperty("connect_instance")]
        public long ConnectInstance { get; set; }

        [JsonProperty("connect_instance_chest")]
        public long ConnectInstanceChest { get; set; }

        [JsonProperty("connect_instance_reward")]
        public long ConnectInstanceReward { get; set; }

        [JsonProperty("connect_leve")]
        public long ConnectLeve { get; set; }

        [JsonProperty("connect_quest_reward")]
        public long ConnectQuestReward { get; set; }

        [JsonProperty("connect_recipe")]
        public long ConnectRecipe { get; set; }

        [JsonProperty("connect_shop")]
        public long ConnectShop { get; set; }

        [JsonProperty("connect_specialshop_cost_1")]
        public long ConnectSpecialshopCost1 { get; set; }

        [JsonProperty("connect_specialshop_cost_2")]
        public long ConnectSpecialshopCost2 { get; set; }

        [JsonProperty("connect_specialshop_cost_3")]
        public long ConnectSpecialshopCost3 { get; set; }

        [JsonProperty("connect_specialshop_receive_1")]
        public long ConnectSpecialshopReceive1 { get; set; }

        [JsonProperty("connect_specialshop_receive_2")]
        public long ConnectSpecialshopReceive2 { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("help")]
        public string Help { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_hq")]
        public string IconHq { get; set; }

        [JsonProperty("icon_lodestone")]
        public string IconLodestone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item_ui_category")]
        public long ItemUiCategory { get; set; }

        [JsonProperty("kind_name")]
        public string KindName { get; set; }

        [JsonProperty("level_equip")]
        public long LevelEquip { get; set; }

        [JsonProperty("level_item")]
        public long LevelItem { get; set; }

        [JsonProperty("lodestone_id")]
        public string LodestoneId { get; set; }

        [JsonProperty("lodestone_type")]
        public string LodestoneType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patch")]
        public PatchClass Patch { get; set; }

        [JsonProperty("price_mid")]
        public long PriceMid { get; set; }

        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("series_name")]
        public string SeriesName { get; set; }

        [JsonProperty("slot_equip")]
        public long SlotEquip { get; set; }

        [JsonProperty("slot_name")]
        public string SlotName { get; set; }

        [JsonProperty("stack_size")]
        public long StackSize { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

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
    public partial class AttributesParam
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_food")]
        public long IsFood { get; set; }

        [JsonProperty("is_relative")]
        public long IsRelative { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("param_patch")]
        public long ParamPatch { get; set; }

        [JsonProperty("percent")]
        public long Percent { get; set; }

        [JsonProperty("percent_hq")]
        public long PercentHq { get; set; }

        [JsonProperty("stat_patch")]
        public long StatPatch { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("value_hq")]
        public long ValueHq { get; set; }
    }


}
