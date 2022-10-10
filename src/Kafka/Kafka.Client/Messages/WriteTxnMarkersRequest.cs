using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record WriteTxnMarkersRequest (
        WriteTxnMarkersRequest.WritableTxnMarker[] MarkersField
    )
    {
        public sealed record WritableTxnMarker (
            long ProducerIdField,
            short ProducerEpochField,
            bool TransactionResultField,
            WriteTxnMarkersRequest.WritableTxnMarker.WritableTxnMarkerTopic[] TopicsField,
            int CoordinatorEpochField
        )
        {
            public sealed record WritableTxnMarkerTopic (
                string NameField,
                int[] PartitionIndexesField
            );
        };
    };
}
