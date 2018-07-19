//using EvilMortyBot.Core.Services;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace EvilMortyBot.Modules.Administration.Services
//{
//    public class PackagesService : INService
//    {
//        public IEnumerable<string> Packages { get; private set; }

//        public PackagesService()
//        {
//            ReloadAvailablePackages();
//        }

//        public void ReloadAvailablePackages()
//        {
//            Packages = Directory.GetDirectories(Path.Combine(AppContext.BaseDirectory, "modules\\"), "EvilMortyBot.Modules.*", SearchOption.AllDirectories)
//                   .SelectMany(x => Directory.GetFiles(x, "EvilMortyBot.Modules.*.dll"))
//                   .Select(x => Path.GetFileNameWithoutExtension(x))
//                   .Select(x =>
//                   {
//                       var m = Regex.Match(x, @"EvilMortyBot\.Modules\.(?<name>.*)");
//                       return m.Groups["name"].Value;
//                   });
//        }
//    }
//}
