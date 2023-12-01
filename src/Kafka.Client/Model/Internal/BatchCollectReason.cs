namespace Kafka.Client.Model.Internal
{
    internal enum BatchCollectReason
    {
        None = 0,
        MaxLingerMsReached = 1,
        MaxSizeExceeded = 2,
        AttributesChanged = 3,
    }
}
