using Coordinator = Kafka.Client.Messages.FindCoordinatorResponse.Coordinator;
using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
    /// <param name="NodeIdField">The node id.</param>
    /// <param name="HostField">The host name.</param>
    /// <param name="PortField">The port.</param>
    /// <param name="CoordinatorsField">Each coordinator result in the response</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FindCoordinatorResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        int NodeIdField,
        string HostField,
        int PortField,
        ImmutableArray<Coordinator> CoordinatorsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static FindCoordinatorResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            default(int),
            "",
            default(int),
            ImmutableArray<Coordinator>.Empty,
            ImmutableArray<TaggedField>.Empty

        );
        /// <summary>
        /// <param name="KeyField">The coordinator key.</param>
        /// <param name="NodeIdField">The node id.</param>
        /// <param name="HostField">The host name.</param>
        /// <param name="PortField">The port.</param>
        /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
        /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record Coordinator (
            string KeyField,
            int NodeIdField,
            string HostField,
            int PortField,
            short ErrorCodeField,
            string? ErrorMessageField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static Coordinator Empty { get; } = new(
                "",
                default(int),
                "",
                default(int),
                default(short),
                default(string?),
                ImmutableArray<TaggedField>.Empty

            );
        };
    };
}