namespace Kafka.Client.Model
{
    internal enum BatchCollectReason
    {
        None = 0,
        MaxLingerMsReached = 1,
        MaxSizeExceeded = 2,
        AttributesChanged = 3,
    }
}
