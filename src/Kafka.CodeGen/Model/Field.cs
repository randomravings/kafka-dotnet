namespace Kafka.CodeGen.Model
{
    public sealed record Field(
        string Name,
        FieldType Type,
        FieldProperties Properties,
        object DefaultValue
    );
}
