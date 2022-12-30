﻿using Kafka.Client.Server;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<int> Select(Cluster cluster, TopicName topic, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken = default);

        /**
         * This is called when partitioner is closed.
         */
        void Close();
    }
}
