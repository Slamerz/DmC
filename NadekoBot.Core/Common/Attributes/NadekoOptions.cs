using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilMortyBot.Common.Attributes
{
    public class EvilMortyOptions : Attribute
    {
        public Type OptionType { get; set; }

        public EvilMortyOptions(Type t)
        {
            this.OptionType = t;
        }
    }
}
