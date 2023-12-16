namespace Kafka.CodeGen.Model
{
    public sealed record RecordsFieldType(
    ) : FieldType(
        "records"
    )
    {
        public static readonly RecordsFieldType Instance = new();
    }
}
