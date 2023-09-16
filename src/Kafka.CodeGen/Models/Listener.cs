namespace Kafka.CodeGen.Models
{
    [Flags]
    public enum Listener
    {
        None,
        ZkBroker,
        Broker,
        Controller
    }
}
