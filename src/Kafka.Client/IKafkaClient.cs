using Kafka.Client.Config;
using Kafka.Client.IO;

namespace Kafka.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKafkaClient :
        IDisposable
    {
        /// <summary>
        /// Gets the admin interface.
        /// </summary>
        ITopics Topics { get; }

        /// <summary>
        /// Gets the admin interface.
        /// </summary>
        IConsumerGroups ConsumerGroups { get; }

        /// <summary>
        /// Creates a new input stream to cluster for writing records.
        /// </summary>
        /// <returns></returns>
        IInputStreamBuilder CreateInputStream();

        /// <summary>
        /// Creates a new input stream to cluster for writing records.
        /// </summary>
        /// <returns></returns>
        IInputStreamBuilder CreateInputStream(Action<InputStreamConfig> configure);

        /// <summary>
        /// Creates a new output stream from cluster for reading records.
        /// </summary>
        /// <returns></returns>
        IOutputStreamBuilder CreateOuputStream();

        /// <summary>
        /// Creates a new output stream from cluster for reading records.
        /// </summary>
        /// <returns></returns>
        IOutputStreamBuilder CreateOuputStream(Action<OutputStreamConfig> configure);

        /// <summary>
        /// Perform graceful shut down of client and free up resources.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask Close(CancellationToken cancellationToken);
    }
}
