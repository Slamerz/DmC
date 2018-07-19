using EvilMortyBot.Modules.FF14.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvilMortyBot.Modules.FF14.Extensions
{
    public static class Extensions
    {
        public static string ToJson(this Achievements self) => JsonConvert.SerializeObject(self, AchConverter.Settings);
        public static string ToJson(this Actions self) => JsonConvert.SerializeObject(self, ActConverter.Settings);


        public static string GetCheckMark(this long a)
        {
            string s = "";
            switch (a)
            {
                case 0:
                    s = "❌";
                    break; 
                case 1:
                    s = ":white_check_mark:";
                    break;

                default: 
                    s = "That wasn't a Bool";
                    break;
            }
            return s;
        }
        public static string GetCheckMark(this bool a)
        {
            string s;
            if(a) s = ":white_check_mark:";
            else s = "❌";
            return s;
        }
        public static string GetGender(this string a)
        {
            string s = "";
            switch (a)
            {
                case "Male":
                    s = "♂";
                    break;
                case "Female":
                    s = "♀";
                    break;

            }
            return s;
        }
    }
    



}
