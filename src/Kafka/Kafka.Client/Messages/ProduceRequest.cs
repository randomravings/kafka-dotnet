using Kafka.Common.Records;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ProduceRequest (
        string TransactionalIdField,
        short AcksField,
        int TimeoutMsField,
        ProduceRequest.TopicProduceData[] TopicDataField
    )
    {
        public sealed record TopicProduceData (
            string NameField,
            ProduceRequest.TopicProduceData.PartitionProduceData[] PartitionDataField
        )
        {
            public sealed record PartitionProduceData (
                int IndexField,
                IRecords RecordsField
            );
        };
    };
}
