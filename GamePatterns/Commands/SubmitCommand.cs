using GamePatterns.Modules;
using GamePatterns.Objects;
using System.Linq;

namespace GamePatterns.Commands
{
    public class SubmitCommand : IGameCommand
    {
        public void Execute(IGameObject gameObject)
        {
            if (gameObject.Modules.Any(m => m is InteractModule))
            {

            }
        }
    }
}
