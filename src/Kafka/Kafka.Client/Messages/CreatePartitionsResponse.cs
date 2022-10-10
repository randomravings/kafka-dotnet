using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreatePartitionsResponse (
        int ThrottleTimeMsField,
        CreatePartitionsResponse.CreatePartitionsTopicResult[] ResultsField
    )
    {
        public sealed record CreatePartitionsTopicResult (
            string NameField,
            short ErrorCodeField,
            string ErrorMessageField
        );
    };
}
