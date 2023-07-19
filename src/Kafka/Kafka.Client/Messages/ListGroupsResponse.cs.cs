using Kafka.Common.Model;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponse.ListedGroup;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="GroupsField">Each group in the response.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListGroupsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<ListedGroup> GroupsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static ListGroupsResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<ListedGroup>.Empty,
            ImmutableArray<TaggedField>.Empty

        );
        /// <summary>
        /// <param name="GroupIdField">The group ID.</param>
        /// <param name="ProtocolTypeField">The group protocol type.</param>
        /// <param name="GroupStateField">The group state name.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record ListedGroup (
            string GroupIdField,
            string ProtocolTypeField,
            string GroupStateField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static ListedGroup Empty { get; } = new(
                "",
                "",
                "",
                ImmutableArray<TaggedField>.Empty

            );
        };
    };
}