namespace Kafka.CodeGen.Models
{
    public sealed record StructFieldType(
        string Name
    ) : FieldType(
        Name
    );
}
