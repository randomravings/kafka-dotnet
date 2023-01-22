using System.Net;

namespace Kafka.Common.Network
{
    public interface ITransport :
        IDisposable
    {
        bool IsConnected { get; }
        DnsEndPoint RemoteEndPoint { get; }
        EndPoint LocalEndPoint { get; }
        Task Connect(CancellationToken cancellationToken = default);
        Task Disconnect(CancellationToken cancellationToken = default);
        Task Handshake(CancellationToken cancellationToken = default);
        Task<byte[]> HandleRequest(
            byte[] requestBytes,
            int offset,
            int length,
            CancellationToken cancellationToken
        );
        Task Close(CancellationToken cancellationToken = default);
    }
}
