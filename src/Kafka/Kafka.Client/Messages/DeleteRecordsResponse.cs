using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteRecordsResponse (
        int ThrottleTimeMsField,
        DeleteRecordsResponse.DeleteRecordsTopicResult[] TopicsField
    )
    {
        public sealed record DeleteRecordsTopicResult (
            string NameField,
            DeleteRecordsResponse.DeleteRecordsTopicResult.DeleteRecordsPartitionResult[] PartitionsField
        )
        {
            public sealed record DeleteRecordsPartitionResult (
                int PartitionIndexField,
                long LowWatermarkField,
                short ErrorCodeField
            );
        };
    };
}
