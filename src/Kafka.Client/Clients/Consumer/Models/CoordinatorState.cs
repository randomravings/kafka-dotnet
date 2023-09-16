namespace Kafka.Client.Clients.Consumer.Models
{
    internal enum CoordinatorState : long
    {
        None = 0,
        Created = 1,
        Consuming = 2,
        Rebalancing = 3,
    }
}
