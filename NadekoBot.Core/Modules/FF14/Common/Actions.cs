using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text;

namespace EvilMortyBot.Modules.FF14.Common
{
        public partial class Actions
        {
            [JsonProperty("action_category")]
            public long ActionCategory { get; set; }

            [JsonProperty("action_combo")]
            public long ActionCombo { get; set; }

            [JsonProperty("action_data")]
            public long ActionData { get; set; }

            [JsonProperty("action_proc_status")]
            public long ActionProcStatus { get; set; }

            [JsonProperty("action_timeline_hit")]
            public long ActionTimelineHit { get; set; }

            [JsonProperty("action_timeline_use")]
            public long ActionTimelineUse { get; set; }

            [JsonProperty("can_target_dead")]
            public long CanTargetDead { get; set; }

            [JsonProperty("can_target_friendly")]
            public long CanTargetFriendly { get; set; }

            [JsonProperty("can_target_hostile")]
            public long CanTargetHostile { get; set; }

            [JsonProperty("can_target_party")]
            public long CanTargetParty { get; set; }

            [JsonProperty("can_target_self")]
            public long CanTargetSelf { get; set; }

            [JsonProperty("cast_range")]
            public long CastRange { get; set; }

            [JsonProperty("cast_time")]
            public double CastTime { get; set; }

            [JsonProperty("class_name")]
            public string ClassName { get; set; }

            [JsonProperty("classjob_category")]
            public string ClassjobCategory { get; set; }

            [JsonProperty("cost", NullValueHandling = NullValueHandling.Ignore)]
            public long Cost { get; set; }

            [JsonProperty("cost_cp", NullValueHandling = NullValueHandling.Ignore)]
            public long CostCp { get; set; }

            [JsonProperty("cost_hp", NullValueHandling = NullValueHandling.Ignore)]
            public long CostHp { get; set; }

            [JsonProperty("cost_mp", NullValueHandling = NullValueHandling.Ignore)]
            public long CostMp { get; set; }

            [JsonProperty("cost_tp", NullValueHandling = NullValueHandling.Ignore)]
            public long CostTp { get; set; }

            [JsonProperty("effect_range")]
            public long EffectRange { get; set; }

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

            [JsonProperty("help_html")]
            public string HelpHtml { get; set; }

            [JsonProperty("help_ja")]
            public string HelpJa { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("icon_hq")]
            public string IconHq { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("is_in_game")]
            public long IsInGame { get; set; }

            [JsonProperty("is_pvp")]
            public long IsPvp { get; set; }

            [JsonProperty("is_target_area")]
            public long IsTargetArea { get; set; }

            [JsonProperty("is_trait")]
            public long IsTrait { get; set; }

            [JsonProperty("level")]
            public long Level { get; set; }

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

            [JsonProperty("recast_time")]
            public double RecastTime { get; set; }

            [JsonProperty("spell_group")]
            public long SpellGroup { get; set; }

            [JsonProperty("status_gain_self")]
            public long StatusGainSelf { get; set; }

            [JsonProperty("status_required")]
            public long StatusRequired { get; set; }

            [JsonProperty("type")]
            public long TypeID { get; set; }

            [JsonProperty("type_name")]
            public string TypeName { get; set; }

            [JsonProperty("upgrades")]
            public List<string> Upgrades { get; set; }

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

            [JsonProperty("_cid")]
            public long Cid { get; set; }

            [JsonProperty("_type")]
            public string Type { get; set; }

            [JsonProperty("icon_lodestone")]
            public string IconLodestone { get; set; }
        }
    
        
        public partial class Actions
    {
            public static Actions FromJson(string json) => JsonConvert.DeserializeObject<Actions>(json, ActConverter.Settings);
        }

        internal static class ActConverter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    
}
