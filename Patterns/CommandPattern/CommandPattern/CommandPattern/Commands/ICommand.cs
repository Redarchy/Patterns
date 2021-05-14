namespace CommandPattern.Commands
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
