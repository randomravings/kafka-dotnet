namespace Kafka.CodeGen.Models
{
    public sealed record EmptyFieldType()
        : FieldType("")
    {
        public static readonly EmptyFieldType Instance = new();
    }
}
