namespace Kafka.CodeGen.Model
{
    public sealed record EmptyFieldType()
        : FieldType("")
    {
        public static readonly EmptyFieldType Instance = new();
    }
}
