namespace Kafka.Client.Model
{
    internal readonly record struct AddRecordResult(
        bool Added,
        int SizeRequired
    )
    {
        public static implicit operator AddRecordResult((bool Added, int SizeRequired) v) =>
            new(v.Added, v.SizeRequired)
        ;
    }
}
