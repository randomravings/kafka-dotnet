using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterClientQuotasResponse (
        int ThrottleTimeMsField,
        AlterClientQuotasResponse.EntryData[] EntriesField
    )
    {
        public sealed record EntryData (
            short ErrorCodeField,
            string ErrorMessageField,
            AlterClientQuotasResponse.EntryData.EntityData[] EntityField
        )
        {
            public sealed record EntityData (
                string EntityTypeField,
                string EntityNameField
            );
        };
    };
}
