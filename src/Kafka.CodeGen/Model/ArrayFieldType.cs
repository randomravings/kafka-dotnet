namespace Kafka.CodeGen.Model
{
    public sealed record ArrayFieldType(
        FieldType ItemType
    ) : FieldType(
        "array"
    );
}
