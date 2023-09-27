namespace Kafka.Client.Commands
{
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface ICommand { }
#pragma warning restore CA1040 // Avoid empty interfaces
    public interface ICommand<TResult> :
        ICommand
    {
        Task<TResult> Result();
    }
}
