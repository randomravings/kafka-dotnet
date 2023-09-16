using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Kafka.Client.Clients
{
    public abstract class ClientConfig
    {
        /// <summary>
        /// A list of host/port pairs to use for establishing the initial connection to the Kafka cluster.The client will make use of all servers irrespective of which servers are specified here for bootstrapping—this list only impacts the initial hosts used to discover the full set of servers. This list should be in the form host1:port1, host2:port2,.... Since these servers are just used for the initial connection to discover the full cluster membership (which may change dynamically), this list need not contain the full set of servers(you may want more than one, though, in case a server is down).
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>list</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>high</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("bootstrap.servers")]
        public string BootstrapServers { get; set; } = "";

        /// <summary>
        /// An id string to pass to the server when making requests.The purpose of this is to be able to track the source of requests beyond just ip/port by allowing a logical application name to be included in server-side request logging.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>string</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("client.id")]
        public string ClientId { get; set; } = "";

        /// <summary>
        /// Close idle connections after the number of milliseconds specified by this config.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>300000 (5 minutes)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("connections.max.idle.ms")]
        public long ConnectionsMaxIdleMs { get; set; } = 300000L;

        /// <summary>
        /// Specifies the timeout(in milliseconds) for client APIs.This configuration is used as the default timeout for all client operations that do not specify a timeout parameter.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>int</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>60000 (1 minute)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("default.api.timeout.ms")]
        public int DefaultApiTimeoutMs { get; set; } = 60000;

        /// <summary>
        /// The size of the TCP receive buffer (SO_RCVBUF) to use when reading data. If the value is -1, the OS default will be used.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>int</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>65536 (64 kibibytes)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[-1,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("receive.buffer.bytes")]
        public int ReceiveBufferBytes { get; set; } = 65536;

        /// <summary>
        /// The configuration controls the maximum amount of time the client will wait for the response of a request. If the response is not received before the timeout elapses the client will resend the request if necessary or fail the request if retries are exhausted.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>int</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>30000 (30 seconds)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("request.timeout.ms")]
        public int RequestTimeoutMs { get; set; } = 30000;

        /// <summary>
        /// The size of the TCP send buffer (SO_SNDBUF) to use when sending data. If the value is -1, the OS default will be used.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>int</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>131072 (128 kibibytes)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[-1,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("send.buffer.bytes")]
        public int SendBufferBytes { get; set; } = 131072;

        /// <summary>
        /// The maximum amount of time the client will wait for the socket connection to be established. The connection setup timeout will increase exponentially for each consecutive connection failure up to this maximum.To avoid connection storms, a randomization factor of 0.2 will be applied to the timeout resulting in a random range between 20% below and 20% above the computed value.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>30000 (30 seconds)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("socket.connection.setup.timeout.max.ms")]
        public int SocketConnectionSetupTimeoutMaxMs { get; set; } = 30000;

        /// <summary>
        /// The amount of time the client will wait for the socket connection to be established. If the connection is not built before the timeout elapses, clients will close the socket channel.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>10000 (10 seconds)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>medium</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("socket.connection.setup.timeout.ms")]
        public int SocketConnectionSetupTimeoutMs { get; set; } = 10000;

        /// <summary>
        /// The period of time in milliseconds after which we force a refresh of metadata even if we haven't seen any partition leadership changes to proactively discover any new brokers or partitions.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>300000 (5 minutes)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>low</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("metadata.max.age.ms")]
        public long MetadataMaxAgeMs { get; set; } = 300000L;

        /// <summary>
        /// The maximum amount of time in milliseconds to wait when reconnecting to a broker that has repeatedly failed to connect. If provided, the backoff per host will increase exponentially for each consecutive connection failure, up to this maximum.After calculating the backoff increase, 20% random jitter is added to avoid connection storms.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>1000 (1 second)</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>low</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("reconnect.backoff.max.ms")]
        public long ReconnectBackoffMaxMs { get; set; } = 1000;

        /// <summary>
        /// The base amount of time to wait before attempting to reconnect to a given host.This avoids repeatedly connecting to a host in a tight loop.This backoff applies to all connection attempts by the client to a broker.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>50</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>low</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("reconnect.backoff.ms")]
        public long ReconnectBackoffMs { get; set; } = 50;

        /// <summary>
        /// Setting a value greater than zero will cause the client to resend any request that fails with a potentially transient error.It is recommended to set the value to either zero or `MAX_VALUE` and use corresponding timeout parameters to control how long a client should retry a request.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>int</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>2147483647</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...,2147483647]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>low</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("retries")]
        public int Retries { get; set; } = 2147483647;

        /// <summary>
        /// The amount of time to wait before attempting to retry a failed request. This avoids repeatedly sending requests in a tight loop under some failure scenarios.
        /// <list type="table">
        ///   <item>
        ///     <term>Type</term>
        ///     <description>long</description>
        ///   </item>
        ///   <item>
        ///     <term>Default</term>
        ///     <description>100</description>
        ///   </item>
        ///   <item>
        ///     <term>Valid Values</term>
        ///     <description>[0,...]</description>
        ///   </item>
        ///   <item>
        ///     <term>Importance</term>
        ///     <description>low</description>
        ///   </item>
        /// </list>
        /// </summary>
        [JsonPropertyName("retry.backoff.ms")]
        public long RetryBackoffMs { get; set; } = 100;

        public override string ToString()
        {
            var sb = new StringBuilder();
            var properties = EnumerateJsonConfig(this);
            foreach ((var name, var value) in properties)
            {
                sb.Append(name);
                sb.Append(": ");
                if (value == null)
                    sb.Append("<null>");
                else
                    sb.Append(value.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }


        private static SortedList<string, object?> EnumerateJsonConfig<T>(T instance)
        {
            var items = new SortedList<string, object?>();
            foreach (var property in typeof(T).GetProperties())
            {
                var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                if (jsonPropertyName == null)
                    continue;
                var name = jsonPropertyName.Name;
                var value = property.GetValue(instance, null);
                items.Add(name, value);
            }
            return items;
        }
    }
}
