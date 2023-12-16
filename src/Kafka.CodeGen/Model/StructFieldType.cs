namespace Kafka.CodeGen.Model
{
    public sealed record StructFieldType(
        string Name
    ) : FieldType(
        Name
    );
}
