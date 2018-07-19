using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilMortyBot.Modules.Games.Common.ChatterBot
{
    public interface IChatterBotSession
    {
        Task<string> Think(string input);
    }
}
