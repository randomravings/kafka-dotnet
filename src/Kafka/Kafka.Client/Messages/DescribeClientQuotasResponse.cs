using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClientQuotasResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        DescribeClientQuotasResponse.EntryData[] EntriesField
    )
    {
        public sealed record EntryData (
            DescribeClientQuotasResponse.EntryData.EntityData[] EntityField,
            DescribeClientQuotasResponse.EntryData.ValueData[] ValuesField
        )
        {
            public sealed record ValueData (
                string KeyField,
                double ValueField
            );
            public sealed record EntityData (
                string EntityTypeField,
                string EntityNameField
            );
        };
    };
}
