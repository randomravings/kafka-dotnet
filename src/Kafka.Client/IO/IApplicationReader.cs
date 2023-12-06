namespace Kafka.Client.IO
{
    public interface IApplicationReader :
        IReader
    { }

    public interface IApplicationReader<TKey, TValue> :
        IReader<TKey, TValue>
    { }
}
