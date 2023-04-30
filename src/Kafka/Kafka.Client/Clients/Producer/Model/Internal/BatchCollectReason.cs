namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal enum BatchCollectReason
    {
        None = 0,
        MaxInFlightReached = 1,
        MaxLingerMsReached = 2,
        MaxSizeExceeded = 3,
        ControlCommandIssued = 4,
        AttributesChanged = 5
    }
}
