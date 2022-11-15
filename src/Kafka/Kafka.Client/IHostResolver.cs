using System.Net;

namespace Kafka.Client
{
    public interface IHostResolver
    {
        IPAddress[] Resolve(string host);
    }
}
