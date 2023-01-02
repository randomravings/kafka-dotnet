namespace Kafka.Client.Clients.Producer.Model
{
    public enum TxnState
    {
        None = 0,
        Active = 1,
        Committed = 2,
        Aborted = 3,
        Error = 4
    }
}
