using GamePatterns.Objects;

namespace GamePatterns.Commands
{
    public interface IGameCommand
    {
        void Execute(IGameObject gameObject);
    }
}
