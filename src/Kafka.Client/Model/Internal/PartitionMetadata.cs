﻿using Kafka.Common.Model;

namespace Kafka.Client.Model.Internal
{
    internal sealed record PartitionMetadata(
        Partition Partition,
        NodeId LeaderId,
        string Host,
        int Port
    );
}
