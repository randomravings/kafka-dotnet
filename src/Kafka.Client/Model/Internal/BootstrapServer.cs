namespace Kafka.Client.Model.Internal
{
    internal readonly record struct BootstrapServer(
        string Host,
        int Port
    )
    {
        public static implicit operator BootstrapServer(
            (string Host, int Port) value
        ) => new(value.Host, value.Port);
    }
}
