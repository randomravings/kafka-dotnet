using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteRecordsRequest (
        DeleteRecordsRequest.DeleteRecordsTopic[] TopicsField,
        int TimeoutMsField
    )
    {
        public sealed record DeleteRecordsTopic (
            string NameField,
            DeleteRecordsRequest.DeleteRecordsTopic.DeleteRecordsPartition[] PartitionsField
        )
        {
            public sealed record DeleteRecordsPartition (
                int PartitionIndexField,
                long OffsetField
            );
        };
    };
}
