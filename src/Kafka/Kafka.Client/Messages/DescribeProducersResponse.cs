using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeProducersResponse (
        int ThrottleTimeMsField,
        DescribeProducersResponse.TopicResponse[] TopicsField
    )
    {
        public sealed record TopicResponse (
            string NameField,
            DescribeProducersResponse.TopicResponse.PartitionResponse[] PartitionsField
        )
        {
            public sealed record PartitionResponse (
                int PartitionIndexField,
                short ErrorCodeField,
                string ErrorMessageField,
                DescribeProducersResponse.TopicResponse.PartitionResponse.ProducerState[] ActiveProducersField
            )
            {
                public sealed record ProducerState (
                    long ProducerIdField,
                    int ProducerEpochField,
                    int LastSequenceField,
                    long LastTimestampField,
                    int CoordinatorEpochField,
                    long CurrentTxnStartOffsetField
                );
            };
        };
    };
}
