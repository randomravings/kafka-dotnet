namespace Kafka.CodeGen.Models
{
    public sealed record RecordsFieldType(
    ) : FieldType(
        "records"
    )
    {
        public static readonly RecordsFieldType Instance = new();
    }
}
