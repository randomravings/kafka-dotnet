using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponseData.ListedGroup;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="GroupsField">Each group in the response.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record ListGroupsResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<ListedGroup> GroupsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static ListGroupsResponseData Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<ListedGroup>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="GroupIdField">The group ID.</param>
        /// <param name="ProtocolTypeField">The group protocol type.</param>
        /// <param name="GroupStateField">The group state name.</param>
        /// <param name="GroupTypeField">The group type name.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record ListedGroup (
            string GroupIdField,
            string ProtocolTypeField,
            string GroupStateField,
            string GroupTypeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static ListedGroup Empty { get; } = new(
                "",
                "",
                "",
                "",
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
