using Discord;
using Discord.Commands;
using Discord.WebSocket;
using EvilMortyBot.Common.Attributes;
using EvilMortyBot.Extensions;
using EvilMortyBot.Modules.Xp.Common;
using EvilMortyBot.Modules.Xp.Services;
using EvilMortyBot.Core.Services.Database.Models;
using Image = ImageSharp.Image;
using System.Diagnostics;
using System.Linq;
using EvilMortyBot.Core.Services;
using System.Threading.Tasks;
using ImageSharp.Formats;
using EvilMortyBot.Modules.Utility.Common;
using EvilMortyBot.Modules.Utility.Services;
using ImageSharp;
using System.IO;

namespace EvilMortyBot.Modules.Utility
{
    public partial class Utility
    {
        [Group]
        public class Spoilers : EvilMortySubmodule<SpoilersService>
        {
            
            //Say hello again
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            public async Task Say([Remainder] string echo)
            {
                await Context.Message.DeleteAsync();
                await ReplyAsync(echo);
            }
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            public async Task Post(string uri)
            {
                await Context.Channel.TriggerTypingAsync();
                var format = uri.IsImage();
                var img = await _service.DownloadImageAsync(uri);
                await Context.Channel.SendFileAsync(img.ToStream(format), $"DownloadedImg" + format).ConfigureAwait(false);
            }
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireContext(ContextType.Guild)]
            public async Task ImageMacro(string uri, [Remainder] string txt)
            {
                Image<Rgba32> img;
                await Context.Channel.TriggerTypingAsync();
                if (txt.Contains("/"))
                {
                    string[] t = txt.Split('/');
                    img = await _service.MakinMemes(uri, t[0], t[1]);
                }
                else
                {
                    img = await _service.MakinMemes(uri, txt);
                }
                string type = uri.IsImage();

                await Context.Channel.SendFileAsync(img.ToStream(type), $"Memery.{type}").ConfigureAwait(false);
            }
            [EvilMortyCommand, Usage, Description, Aliases]
            [RequireBotPermission(GuildPermission.ManageMessages)]
            [RequireContext(ContextType.Guild)]
            public async Task Spoiler([Remainder] string spoiler)
            {
                await Context.Message.DeleteAsync();
                await Context.Channel.TriggerTypingAsync();


                //Youtube
                if (spoiler.StartsWith("https://www.youtube.com") || spoiler.StartsWith("youtube.com") || spoiler.StartsWith("https://youtu.be"))
                {
                    string vlink = spoiler.GetEndOf(extra: 2);
                    if (vlink == "")
                    {
                        vlink = spoiler.GetEndOf("/");
                    }
                    string slink = "http://www.nospoiler.com/y/" + vlink;
                    await Context.Channel.SendMessageAsync("**Spoiler from **" + Context.User.Username);
                    await ReplyAsync(slink);
                    return;

                }

                //static images
                var format = spoiler.IsImage();
                if (format != "false")
                {

                    var img = await _service.SpoilerImg(spoiler);
                    await Context.Channel.SendFileAsync(img.ToStream(), "Spoiler.gif", "spoil").ConfigureAwait(false);
                    return;
                } else //text
                {
                    IChannel ch = await Context.Client.GetChannelAsync(441808361126887425);
                    var img = _service.SpoilerTxt(spoiler);
                    var msg = await Context.Channel.SendFileAsync(img, "Spoiler.Gif");
                    var att = msg.Attachments;
                    string url = "";
                    foreach (Attachment s in att)
                    {
                        url = s.Url;
                        break;
                    }
                    msg.DeleteAfter(0);

                    await Context.Channel.EmbedAsync(new EmbedBuilder().WithOkColor()
                .WithAuthor(eab => eab.WithIconUrl(Context.User.GetAvatarUrl(ImageFormat.Gif))
                .WithName(Context.User.Username)
                .WithUrl(Context.User.Mention))
                .WithTitle("Spoilers")
                .WithImageUrl(url));
                }

                



            }

        }
    }


}
