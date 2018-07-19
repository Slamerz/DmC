using System.Threading.Tasks;
using Discord;

namespace EvilMortyBot.Common.ModuleBehaviors
{
    public interface IInputTransformer
    {
        Task<string> TransformInput(IGuild guild, IMessageChannel channel, IUser user, string input);
    }
}
