namespace Kafka.Client.Clients.Producer.Model
{
    public enum BatchAccumulatedReason
    {
        None = 0,
        MaxInFlightReached = 1,
        MaxLingerMsReached = 2,
        MaxSizeExceeded = 3
    }
}
