namespace Kafka.Common.Protocol
{
    public interface IRequest
    {
        public int Size { get; }
    }
    public interface IRequest<TRequest> :
        IRequest
        where TRequest : notnull, IRequest<TRequest>, new()
    { }
}
