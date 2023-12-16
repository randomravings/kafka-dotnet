namespace Kafka.CodeGen.Model
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
