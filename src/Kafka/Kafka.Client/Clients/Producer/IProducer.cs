namespace Kafka.Client.Clients.Producer
{
    internal interface IProducer<TKey, TValue> :
        IClient
    {
        ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            ProducerRecord<TKey, TValue> record
        );
    }
}
