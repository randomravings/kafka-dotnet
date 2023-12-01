namespace Kafka.Client.Model.Internal
{
    internal readonly record struct AddRecordResult(
        bool Added,
        int SizeRequired
    )
    {
        public static implicit operator AddRecordResult(
            (bool Added, int SizeRequired) value
        ) => new(value.Added, value.SizeRequired);
    }
}
