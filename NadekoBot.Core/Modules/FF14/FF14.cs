using Discord.Commands;
using Discord;
using EvilMortyBot.Core.Common;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Common.TypeReaders.Models;
using EvilMortyBot.Extensions;
using EvilMortyBot.Modules.FF14.Services;
using EvilMortyBot.Modules.FF14.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using EvilMortyBot.Common;

namespace EvilMortyBot.Modules.FF14
{
    public partial class FF14 : EvilMortyTopLevelModule<FF14Service>
    {
        
        [EvilMortyCommand, Usage, Description, Aliases]
        [RequireContext(ContextType.Guild)]
        public async Task FF14List()
        {
            EvilMortyRandom rng = new EvilMortyRandom();

            string path1 = @"C:\Users\dreamsketcher\Downloads\j\";
            //2017
            for (int i = 1000; i < 1100; i++)
            {
                await Context.Channel.TriggerTypingAsync().ConfigureAwait(false);
                string api = "https://api.xivdb.com/";
                var url = api + "character/" + i.ToString();
                var path2 = "CharJson" + i.ToString() + ".json";
                var path = path1 + path2;
                var res = await _service.Http.GetStringAsync(url).ConfigureAwait(false);

                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    File.WriteAllText(path, res);
                }

                _log.Warn("I am on page " + i.ToString() + "  I got " + i.ToString());

            }
            await Context.Channel.SendMessageAsync("Jobs Done, Jesus that was alot");



            /*if (slist.Count == 0)
            {
                await Context.Channel.SendMessageAsync("Nother returned");
            }
            else
            {
                await Context.Channel.SendMessageAsync(slist.Count.ToString());
                
                foreach (string s in slist)
                {
                    i++;

                    embed.AddField("link", s);

                    if (i == 12)
                    {
                        i = 0;
                        await Context.Channel.EmbedAsync(embed);
                        embed = new Discord.EmbedBuilder().WithOkColor();
                    }
                }
                await Context.Channel.EmbedAsync(embed);
            }
           */

        }
        [EvilMortyCommand, Usage, Description, Aliases]
        [RequireContext(ContextType.Guild)]
        public async Task FF14Item([Remainder] string s)
        {
            //http://api.xivdb.com/search?string=Queary&page=#
            await Context.Channel.TriggerTypingAsync().ConfigureAwait(false);
            string api = "https://api.xivdb.com/";
            var url = api + "search?string=" +s;

            var res = await _service.Http.GetStringAsync(url).ConfigureAwait(false);
            await Context.Channel.SendMessageAsync(url);

            try
            {
                //var item = JsonConvert.DeserializeObject<Search>(res);
                var item = JsonConvert.DeserializeObject<Search>(res);
                try
                {
                    if (item.Achievements.Paging.Total != 0)
                    {
                        var embed = new EmbedBuilder().WithOkColor().WithTitle("Achievments");
                        await Context.Channel.SendMessageAsync(item.Achievements.Results.Count.ToString());
                        foreach (SearchAchievement b in item.Achievements.Results)
                        {
                            if(b.Name == null)
                            {
                                await Context.Channel.SendMessageAsync("That one was null?");
                                return;
                            }
                            await Context.Channel.SendMessageAsync("I found one");
                            await Context.Channel.SendMessageAsync(b.Name);
                            embed.AddField("Name", b.Name, true);
                            embed.AddField("URL", b.UrlXivdb, true);
                            embed.AddField("ID", b.Id, true);
                            await Context.Channel.EmbedAsync(embed);
                        }  
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("I didn't get an embed");
                    }
                }
                catch(Exception ex)
                {
                    _log.Error(ex);
                }     
        }
            catch(Exception ex)
            {
                _log.Error(ex);
            }

        }

        [EvilMortyCommand, Usage, Description, Aliases]
        [RequireContext(ContextType.Guild)]
        public async Task FF14Ach([Remainder] string s)
        {
            //http://api.xivdb.com/search?string=Queary&page=#
            await Context.Channel.TriggerTypingAsync().ConfigureAwait(false);
            string api = "https://api.xivdb.com/";
            var searchurl = api + "search?one=achievements&order_field=ID&order_direction=asc&string=" + s;
            try
            {
                var res = await _service.Http.GetStringAsync(searchurl).ConfigureAwait(false);
                var a = JsonConvert.DeserializeObject<Search>(res); 
                //var item = JsonConvert.DeserializeObject<Search>(res);
                try
                {
                    string achurl = api + "achievement/" + a.Achievements.Results[0].Id.ToString();
                    var res1 = await _service.Http.GetStringAsync(achurl).ConfigureAwait(false);
                    var b = JsonConvert.DeserializeObject<Achievements>(res1);
                    if (b != null)
                    {
                        await Context.Channel.EmbedAsync(_service.GetAch(b));
                        if(b.Title != null)
                        {
                            await Context.Channel.SendMessageAsync("__**Rewarded Title**__");
                            await Context.Channel.EmbedAsync(_service.GetTit(b.Title));
                        }
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Sorry, couldn't find anything, could you try again?");
                    }
                   
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                await Context.Channel.SendMessageAsync("Looks like there aren't any matching achievements, did you spell it right?");
            }

        }





        [EvilMortyCommand, Usage, Description, Aliases]
        [RequireContext(ContextType.Guild)]
        public async Task FF14Act([Remainder] string s)
        {
            //http://api.xivdb.com/search?string=Queary&page=#
            await Context.Channel.TriggerTypingAsync().ConfigureAwait(false);
            string api = "https://api.xivdb.com/";
            var searchurl = api + "search?one=actions&order_field=ID&order_direction=asc&string=" + s;


            try
            {
                var res = await _service.Http.GetStringAsync(searchurl).ConfigureAwait(false);
                var a = JsonConvert.DeserializeObject<Search>(res);
                //var item = JsonConvert.DeserializeObject<Search>(res);
                try
                {
                    string achurl = api + "action/" + a.Actions.Results[0].Id.ToString();
                    var res1 = await _service.Http.GetStringAsync(achurl).ConfigureAwait(false);
                    var b = JsonConvert.DeserializeObject<Actions>(res1);
                    if (b != null)
                    {

                        await Context.Channel.EmbedAsync(_service.GetAct(b));
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Sorry, couldn't find anything, could you try again?");
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                await Context.Channel.SendMessageAsync("Looks like there aren't any matching achievements, did you spell it right?");
            }
        }

        [EvilMortyCommand, Usage, Description, Aliases]
        [RequireContext(ContextType.Guild)]
        public async Task FF14Char([Remainder] string s)
        {
            //http://api.xivdb.com/search?string=Queary&page=#
            await Context.Channel.TriggerTypingAsync().ConfigureAwait(false);
            string api = "https://api.xivdb.com/";
            var searchurl = api + "search?one=character&order_field=ID&order_direction=asc&string=" + s;


            try
            {
                var res = await _service.Http.GetStringAsync(searchurl).ConfigureAwait(false);
                var a = JsonConvert.DeserializeObject<Search>(res);
                //var item = JsonConvert.DeserializeObject<Search>(res);
                try
                {
                    string achurl = api + "action/" + a.Actions.Results[0].Id.ToString();
                    var res1 = await _service.Http.GetStringAsync(achurl).ConfigureAwait(false);
                    var b = JsonConvert.DeserializeObject<Actions>(res1);
                    if (b != null)
                    {

                        await Context.Channel.EmbedAsync(_service.GetAct(b));
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Sorry, couldn't find anything, could you try again?");
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                await Context.Channel.SendMessageAsync("Looks like there aren't any matching achievements, did you spell it right?");
            }


        }







        }
}
