namespace Kafka.CodeGen.Model
{
    public sealed record ScalarFieldType(
        string Name
    ) : FieldType(
        Name
    );
}
