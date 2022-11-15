namespace Kafka.CodeGen.Models
{
    public sealed record ScalarFieldType(
        string Name
    ) : FieldType(
        Name
    );
}
