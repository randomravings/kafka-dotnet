namespace Kafka.Client.Commands
{
    public interface ICommand { }
    public interface ICommand<TResult> :
        ICommand
    {
        Task<TResult> Result();
    }
}
