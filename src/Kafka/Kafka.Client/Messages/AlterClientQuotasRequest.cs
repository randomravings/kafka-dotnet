using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterClientQuotasRequest (
        AlterClientQuotasRequest.EntryData[] EntriesField,
        bool ValidateOnlyField
    )
    {
        public sealed record EntryData (
            AlterClientQuotasRequest.EntryData.EntityData[] EntityField,
            AlterClientQuotasRequest.EntryData.OpData[] OpsField
        )
        {
            public sealed record OpData (
                string KeyField,
                double ValueField,
                bool RemoveField
            );
            public sealed record EntityData (
                string EntityTypeField,
                string EntityNameField
            );
        };
    };
}
