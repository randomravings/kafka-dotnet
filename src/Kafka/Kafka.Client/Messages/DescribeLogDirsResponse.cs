using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeLogDirsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        DescribeLogDirsResponse.DescribeLogDirsResult[] ResultsField
    )
    {
        public sealed record DescribeLogDirsResult (
            short ErrorCodeField,
            string LogDirField,
            DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic[] TopicsField,
            long TotalBytesField,
            long UsableBytesField
        )
        {
            public sealed record DescribeLogDirsTopic (
                string NameField,
                DescribeLogDirsResponse.DescribeLogDirsResult.DescribeLogDirsTopic.DescribeLogDirsPartition[] PartitionsField
            )
            {
                public sealed record DescribeLogDirsPartition (
                    int PartitionIndexField,
                    long PartitionSizeField,
                    long OffsetLagField,
                    bool IsFutureKeyField
                );
            };
        };
    };
}
