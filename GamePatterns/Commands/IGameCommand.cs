namespace GamePatterns.Commands
{
    public interface IGameCommand
    {
        void Execute();
    }

    public interface IGameCommand<T> : IGameCommand
    {
        void Execute(T parameter);
    }
}
