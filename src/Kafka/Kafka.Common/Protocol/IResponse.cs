namespace Kafka.Common.Protocol
{
    public interface IResponse
    {
        public int Size { get; }
    }
    public interface IResponse<TResponse> :
        IResponse
        where TResponse : notnull, IResponse<TResponse>, new()
    { }
}
