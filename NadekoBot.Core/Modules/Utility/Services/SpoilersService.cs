using EvilMortyBot.Extensions;
using EvilMortyBot.Core.Services;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ImageSharp;
using Image = ImageSharp.Image;
using System.Net.Http;
using SixLabors.Fonts;
using System.IO;
using ImageSharp.Drawing;
using ImageSharp.Drawing.Brushes;
using ImageSharp.Drawing.Pens;
using SixLabors.Primitives;
using System.Numerics;
using System.Text;
using System.Linq;
using System;
using ImageMagick;
using ImageSharp.Formats;

namespace EvilMortyBot.Modules.Utility.Services
{
    public class SpoilersService : INService
    {
        private readonly ConcurrentDictionary<string, byte[]> _imageStreams
            = new ConcurrentDictionary<string, byte[]>();
        private readonly HttpClient http = new HttpClient();
        private readonly FontCollection _fonts = new FontCollection();
        private Font _Meme;
        private Font _Spoil;
        private Font _Spoiltxt;

        public SpoilersService()
        {
            if (Directory.Exists("data/fonts"))
                foreach (var file in Directory.GetFiles("data/fonts"))
                {
                    _fonts.Install(file);
                }
            InitializeFonts();
        }
        public void InitializeFonts()
        {
            _Meme = _fonts.Find("Impact").CreateFont(20);
            _Spoil = _fonts.Find("Whitney-Bold").CreateFont(40);
            _Spoiltxt = _fonts.Find("Whitney-Bold").CreateFont(18);
        }
        //External
        public Task<Image<Rgba32>> MakinMemes(string uri, string txt) => Task.Run(async () =>
        {
            var img = await DownloadImageAsync(uri);
            var brush = Brushes.Solid<Rgba32>(Rgba32.White);
            var pen = new Pen<Rgba32>(Rgba32.Black, 3);
            var center = new PointF(1, img.Height / 2);
            _Meme = _fonts.Find("Impact").CreateFont(img.Width * 0.064f);
            img.DrawText(txt, _Meme, brush, pen, center, new TextGraphicsOptions(true)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                WrapTextWidth = img.Width - 40
            });
            return img;
        }
        );
        public Task<Image<Rgba32>> MakinMemes(string uri, string txt1, string txt2) => Task.Run(async () =>
        {
            var img = await DownloadImageAsync(uri);
            var brush = Brushes.Solid<Rgba32>(Rgba32.White);
            var pen = new Pen<Rgba32>(Rgba32.Black, 3);
            var top = new PointF(1, img.Height / 4);
            var bot = new PointF(1, img.Height / 4 * 3);
            _Meme = _fonts.Find("Impact").CreateFont(img.Width * 0.064f);
            img.DrawText(txt1, _Meme, brush, pen, top, new TextGraphicsOptions(true)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                WrapTextWidth = img.Width - 40
            });
            img.DrawText(txt2, _Meme, brush, pen, bot, new TextGraphicsOptions(true)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                WrapTextWidth = img.Width - 40
            });
            return img;

        });
        public Task<MagickImageCollection> SpoilerImg(string uri) => Task.Run(async () =>
        {
            //load image
            var img2 = await DownloadImageAsync(uri);
            //create spoiler warning image
            Image<Rgba32> img1 = new Image<Rgba32>(img2.Width, img2.Height);
            _Spoil = _fonts.Find("Whitney-Bold").CreateFont(img2.Width * 0.064f);
            var fill = Brushes.Solid<Rgba32>(Rgba32.Black);
            var brush = Brushes.Solid<Rgba32>(Rgba32.White);
            var rect = new Rectangle(0, 0, img2.Width, img2.Height);
            img1.BackgroundColor(Rgba32.Black, rect);
            img1.DrawText("Spoiler Warning" + "\r\n" + "(Mouse over to view)", _Spoil, brush, new PointF(10, 10), new TextGraphicsOptions(true)
            {
                WrapTextWidth = img1.Width - 20
            });
            MagickImage f1 = new MagickImage(img1.ToStream());
            MagickImage f2 = new MagickImage(img2.ToStream());
            MagickImage[] frames = { f1, f2 };
            var gifs = GetGif(frames);
            var gif = new MagickImageCollection(gifs);
            return gif;
        });
        public Task<MagickImageCollection> SpoilerImgGif(string spoil) => Task.Run(async () =>
        {

            var imgtest = await DownloadImageAsync(spoil);
            var gif = new MagickImageCollection(imgtest.ToStream());
            if (imgtest.IsAnimated)
            {
                gif = new MagickImageCollection(imgtest.ToStream());
            }
            return gif;
        });
        public MemoryStream SpoilerTxt(string spoil)
        {
            var fill = Brushes.Solid<Rgba32>(Rgba32.Black);
            var brush = Brushes.Solid<Rgba32>(Rgba32.White);
            RendererOptions op = new RendererOptions(_Spoiltxt);
            var text = WordWrap(spoil, 120);
            var tsize = TextMeasurer.MeasureBounds(text, op);
            int[] size = { Convert.ToInt32(tsize.Width) + 20, Convert.ToInt32(tsize.Height) + 20 };
            var img2 = new Image<Rgba32>(size[0], size[1]);
            img2.DrawText(text, _Spoiltxt, brush, new PointF(0, 0), new TextGraphicsOptions(true));
            img2.BackgroundColor(Rgba32.Black);
            var img1 = new Image<Rgba32>(img2.Width, img2.Height);
            _Spoil = _fonts.Find("Whitney-Bold").CreateFont(img2.Width * 0.064f);
            var rect = new Rectangle(0, 0, img2.Width, img2.Height);
            img1.BackgroundColor(Rgba32.Black, rect);
            img1.DrawText("Spoiler Warning" + "\r\n" + "(Mouse over to view)", _Spoil, brush, new PointF(0, 0), new TextGraphicsOptions(true)
            {
                WrapTextWidth = img1.Width - 20
            });
            MagickImage f1 = new MagickImage(img1.ToStream());
            MagickImage f2 = new MagickImage(img2.ToStream());
            MagickImage[] frames = { f1, f2 };
            MemoryStream ms = new MemoryStream();
            
                using (MagickImageCollection gif = new MagickImageCollection())
                {
                    gif.Add(f1);
                    gif.Add(f2);

                    for (int i = 0; i < gif.Count; i++)
                    {
                        gif[i].AnimationDelay = 50;
                        gif[i].AnimationIterations = 1;
                    }
                    QuantizeSettings settings = new QuantizeSettings
                    {
                        Colors = 256,
                        DitherMethod = DitherMethod.No
                    };
                    gif.Quantize(settings);
                    gif.Optimize();
                    gif.Write(ms, MagickFormat.Gif);
                    ms.Position = 0;
                }
                return ms;
        }

        //internal
        public MemoryStream GetGif(MagickImage[] frames, int delay = 50)
        {
            //create gif
            using (MagickImageCollection gif = new MagickImageCollection())
            {
                //add all frames
                foreach (MagickImage i in frames)
                {
                    gif.Add(i)
;
                }
                //set delay
                for (int i = 0; i < gif.Count; i++)
                {
                    gif[i].AnimationDelay = delay;
                    gif[i].AnimationIterations = 1;
                }
                QuantizeSettings settings = new QuantizeSettings
                {
                    Colors = 256,
                    DitherMethod = DitherMethod.No
                };
                gif.Quantize(settings);
                gif.Optimize();
                MemoryStream ms = new MemoryStream();
                gif.Write(ms, MagickFormat.Gif);
                return ms;
            }

        }
        public Task<Image<Rgba32>> DownloadImageAsync(string uri) => Task.Run(async () =>
        {

            if (!_imageStreams.TryGetValue(uri, out byte[] s))
            {
                using (var temp = await http.GetStreamAsync(uri))
                {
                    var tempDraw = Image.Load(temp);
                    var format = uri.IsImage();
                    if (format != ".png")
                    {
                        s = tempDraw.ToStream().ToArray();
                    }
                    else
                    {
                        s = tempDraw.ToStream(format).ToArray();
                    }

                }
            }
            var img = Image.Load(s);
            return img;

        });
        public static string WordWrap(string text, int width)
        {
            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if (width < 1)
                return text;

            // Parse each line of text
            for (pos = 0; pos < text.Length; pos = next)
            {
                // Find end of line
                int eol = text.IndexOf(Environment.NewLine, pos);
                if (eol == -1)
                    next = eol = text.Length;
                else
                    next = eol + Environment.NewLine.Length;

                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;
                        if (len > width)
                            len = BreakLine(text, pos, width);
                        sb.Append(text, pos, len);
                        sb.Append(Environment.NewLine);

                        // Trim whitespace following break
                        pos += len;
                        while (pos < eol && Char.IsWhiteSpace(text[pos]))
                            pos++;
                    } while (eol > pos);
                }
                else sb.Append(Environment.NewLine); // Empty line
            }
            return sb.ToString();
        }

        /// <summary>
        /// Locates position to break the given line so as to avoid
        /// breaking words.
        /// </summary>
        /// <param name="text">String that contains line of text</param>
        /// <param name="pos">Index where line of text starts</param>
        /// <param name="max">Maximum line length</param>
        /// <returns>The modified line length</returns>
        private static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
                i--;

            // If no whitespace found, break at maximum length
            if (i < 0)
                return max;

            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
                i--;

            // Return length of text before whitespace
            return i + 1;
        }

    }
}