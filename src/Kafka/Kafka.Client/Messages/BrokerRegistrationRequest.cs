using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using Listener = Kafka.Client.Messages.BrokerRegistrationRequest.Listener;
using Feature = Kafka.Client.Messages.BrokerRegistrationRequest.Feature;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The broker ID.</param>
    /// <param name="ClusterIdField">The cluster id of the broker process.</param>
    /// <param name="IncarnationIdField">The incarnation id of the broker process.</param>
    /// <param name="ListenersField">The listeners of this broker</param>
    /// <param name="FeaturesField">The features on this broker</param>
    /// <param name="RackField">The rack which this broker is in.</param>
    /// <param name="IsMigratingZkBrokerField">Set by a ZK broker if the required configurations for ZK migration are present.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BrokerRegistrationRequest (
        int BrokerIdField,
        string ClusterIdField,
        Guid IncarnationIdField,
        ImmutableArray<Listener> ListenersField,
        ImmutableArray<Feature> FeaturesField,
        string? RackField,
        sbyte IsMigratingZkBrokerField
    ) : Request(62,0,0,0)
    {
        public static BrokerRegistrationRequest Empty { get; } = new(
            default(int),
            "",
            default(Guid),
            ImmutableArray<Listener>.Empty,
            ImmutableArray<Feature>.Empty,
            default(string?),
            default(sbyte)
        );
        /// <summary>
        /// <param name="NameField">The name of the endpoint.</param>
        /// <param name="HostField">The hostname.</param>
        /// <param name="PortField">The port.</param>
        /// <param name="SecurityProtocolField">The security protocol.</param>
        /// </summary>
        public sealed record Listener (
            string NameField,
            string HostField,
            ushort PortField,
            short SecurityProtocolField
        )
        {
            public static Listener Empty { get; } = new(
                "",
                "",
                default(ushort),
                default(short)
            );
        };
        /// <summary>
        /// <param name="NameField">The feature name.</param>
        /// <param name="MinSupportedVersionField">The minimum supported feature level.</param>
        /// <param name="MaxSupportedVersionField">The maximum supported feature level.</param>
        /// </summary>
        public sealed record Feature (
            string NameField,
            short MinSupportedVersionField,
            short MaxSupportedVersionField
        )
        {
            public static Feature Empty { get; } = new(
                "",
                default(short),
                default(short)
            );
        };
    };
}