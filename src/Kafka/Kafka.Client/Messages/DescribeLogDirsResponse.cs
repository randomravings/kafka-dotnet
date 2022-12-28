using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribeLogDirsTopic = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic;
using DescribeLogDirsPartition = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic.DescribeLogDirsPartition;
using DescribeLogDirsResult = Kafka.Client.Messages.DescribeLogDirsResponse.DescribeLogDirsResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ResultsField">The log directories.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeLogDirsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<DescribeLogDirsResult> ResultsField
    ) : Response(35)
    {
        public static DescribeLogDirsResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<DescribeLogDirsResult>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
        /// <param name="LogDirField">The absolute log directory path.</param>
        /// <param name="TopicsField">Each topic.</param>
        /// <param name="TotalBytesField">The total size in bytes of the volume the log directory is in.</param>
        /// <param name="UsableBytesField">The usable size in bytes of the volume the log directory is in.</param>
        /// </summary>
        public sealed record DescribeLogDirsResult (
            short ErrorCodeField,
            string LogDirField,
            ImmutableArray<DescribeLogDirsTopic> TopicsField,
            long TotalBytesField,
            long UsableBytesField
        )
        {
            public static DescribeLogDirsResult Empty { get; } = new(
                default(short),
                "",
                ImmutableArray<DescribeLogDirsTopic>.Empty,
                default(long),
                default(long)
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionsField"></param>
            /// </summary>
            public sealed record DescribeLogDirsTopic (
                string NameField,
                ImmutableArray<DescribeLogDirsPartition> PartitionsField
            )
            {
                public static DescribeLogDirsTopic Empty { get; } = new(
                    "",
                    ImmutableArray<DescribeLogDirsPartition>.Empty
                );
                /// <summary>
                /// <param name="PartitionIndexField">The partition index.</param>
                /// <param name="PartitionSizeField">The size of the log segments in this partition in bytes.</param>
                /// <param name="OffsetLagField">The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition)</param>
                /// <param name="IsFutureKeyField">True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.</param>
                /// </summary>
                public sealed record DescribeLogDirsPartition (
                    int PartitionIndexField,
                    long PartitionSizeField,
                    long OffsetLagField,
                    bool IsFutureKeyField
                )
                {
                    public static DescribeLogDirsPartition Empty { get; } = new(
                        default(int),
                        default(long),
                        default(long),
                        default(bool)
                    );
                };
            };
        };
    };
}