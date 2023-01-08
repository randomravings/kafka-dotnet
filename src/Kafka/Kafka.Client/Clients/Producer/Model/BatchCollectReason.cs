namespace Kafka.Client.Clients.Producer.Model
{
    public enum BatchCollectReason
    {
        None = 0,
        MaxInFlightReached = 1,
        MaxLingerMsReached = 2,
        MaxSizeExceeded = 3,
        ControlCommandIssued = 4
    }
}
