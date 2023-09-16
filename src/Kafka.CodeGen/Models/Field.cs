namespace Kafka.CodeGen.Models
{
    public sealed record Field(
        string Name,
        FieldType Type,
        FieldProperties Properties,
        object DefaultValue
    );
}
