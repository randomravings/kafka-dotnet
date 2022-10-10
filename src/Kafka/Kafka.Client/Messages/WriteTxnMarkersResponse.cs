using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record WriteTxnMarkersResponse (
        WriteTxnMarkersResponse.WritableTxnMarkerResult[] MarkersField
    )
    {
        public sealed record WritableTxnMarkerResult (
            long ProducerIdField,
            WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult[] TopicsField
        )
        {
            public sealed record WritableTxnMarkerTopicResult (
                string NameField,
                WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult.WritableTxnMarkerPartitionResult[] PartitionsField
            )
            {
                public sealed record WritableTxnMarkerPartitionResult (
                    int PartitionIndexField,
                    short ErrorCodeField
                );
            };
        };
    };
}
