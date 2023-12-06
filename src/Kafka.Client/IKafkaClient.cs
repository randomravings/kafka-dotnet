﻿using Kafka.Client.Config;
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
        IReadStreamBuilder CreateInputStream();

        /// <summary>
        /// Creates a new input stream to cluster for writing records.
        /// </summary>
        /// <returns></returns>
        IReadStreamBuilder CreateInputStream(
            Action<ReadStreamConfig> configure
        );

        /// <summary>
        /// Creates a new output stream from cluster for reading records.
        /// </summary>
        /// <returns></returns>
        IWriteStreamBuilder CreateOutputStream();

        /// <summary>
        /// Creates a new output stream from cluster for reading records.
        /// </summary>
        /// <returns></returns>
        IWriteStreamBuilder CreateOutputStream(
            Action<WriteStreamConfig> configure
        );

        /// <summary>
        /// Perform graceful shut down of client and free up resources.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Close(CancellationToken cancellationToken);
    }
}
