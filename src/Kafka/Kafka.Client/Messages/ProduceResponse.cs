using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ProduceResponse (
        ProduceResponse.TopicProduceResponse[] ResponsesField,
        int ThrottleTimeMsField
    )
    {
        public sealed record TopicProduceResponse (
            string NameField,
            ProduceResponse.TopicProduceResponse.PartitionProduceResponse[] PartitionResponsesField
        )
        {
            public sealed record PartitionProduceResponse (
                int IndexField,
                short ErrorCodeField,
                long BaseOffsetField,
                long LogAppendTimeMsField,
                long LogStartOffsetField,
                ProduceResponse.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage[] RecordErrorsField,
                string ErrorMessageField
            )
            {
                public sealed record BatchIndexAndErrorMessage (
                    int BatchIndexField,
                    string BatchIndexErrorMessageField
                );
            };
        };
    };
}
