using Kafka.Client.Clients.Consumer.Models;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStreamAutoCommit<TKey, TValue> :
        IInputStream<TKey, TValue>
    {
        /// <summary>
        /// Forces a commit of stored offsets.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask Commit(
            CancellationToken cancellationToken
        );
    }
}
