using Kafka.Common.Model;

namespace Kafka.Client.Collections
{
    internal sealed class ClusterNodeDictionary<TValue>() :
        SpinningDictionary<ClusterNodeId, TValue>(Compare.ClusterNodeId)
    { }
}
