using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribeClusterBroker = Kafka.Client.Messages.DescribeClusterResponse.DescribeClusterBroker;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no error</param>
    /// <param name="ErrorMessageField">The top-level error message, or null if there was no error.</param>
    /// <param name="ClusterIdField">The cluster ID that responding broker belongs to.</param>
    /// <param name="ControllerIdField">The ID of the controller broker.</param>
    /// <param name="BrokersField">Each broker in the response.</param>
    /// <param name="ClusterAuthorizedOperationsField">32-bit bitfield to represent authorized operations for this cluster.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClusterResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        string ClusterIdField,
        int ControllerIdField,
        ImmutableArray<DescribeClusterBroker> BrokersField,
        int ClusterAuthorizedOperationsField
    ) : Response(60)
    {
        public static DescribeClusterResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            "",
            default(int),
            ImmutableArray<DescribeClusterBroker>.Empty,
            default(int)
        );
        /// <summary>
        /// <param name="BrokerIdField">The broker ID.</param>
        /// <param name="HostField">The broker hostname.</param>
        /// <param name="PortField">The broker port.</param>
        /// <param name="RackField">The rack of the broker, or null if it has not been assigned to a rack.</param>
        /// </summary>
        public sealed record DescribeClusterBroker (
            int BrokerIdField,
            string HostField,
            int PortField,
            string? RackField
        )
        {
            public static DescribeClusterBroker Empty { get; } = new(
                default(int),
                "",
                default(int),
                default(string?)
            );
        };
    };
}