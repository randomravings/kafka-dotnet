using Kafka.Client.Clients.Producer;
using System.Text.Json;

namespace Kafka.Client.UnitTest.Producer
{
    [TestFixture]
    public class ProducerConfigTest
    {
        [Test]
        public void Test()
        {
            var json = @"{""bootstrap.servers"": ""localhost:9092""}";
            var config = JsonSerializer.Deserialize<ProducerConfig>(json);
            Assert.That(config, Is.Not.Null);
            Assert.That(config.BootstrapServers, Is.EqualTo("localhost:9092"));
        }
    }
}
