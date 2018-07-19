using System.Collections.Concurrent;

namespace EvilMortyBot.Modules.Administration.Common
{
    public class Slowmoder
    {
        public ConcurrentDictionary<ulong, uint> Users { get; set; } = new ConcurrentDictionary<ulong, uint>();
        public uint MaxMessages { get; set; }
        public int PerSeconds { get; set; }
    }
}
