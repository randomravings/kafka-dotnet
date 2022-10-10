namespace Kafka.CodeGen.Models
{
    public sealed record ArrayFieldType(
        FieldType ItemType
    ) : FieldType(
        "array"
    );
}
