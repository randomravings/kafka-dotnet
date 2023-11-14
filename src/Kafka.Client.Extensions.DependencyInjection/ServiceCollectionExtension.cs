using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Kafka.Client.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddKafkaClient(this IServiceCollection collection, IConfiguration configuration) =>
            AddKafkaClient(collection, configuration, "KafkaClient")
        ;

        public static IServiceCollection AddKafkaClient(this IServiceCollection collection, IConfiguration configuration, string key)
        {
            var properties = MapProperties();
            collection.Configure<KafkaClientConfig>(kafkaClientConfig =>
                Configure(
                    kafkaClientConfig,
                    configuration,
                    key,
                    properties
                )
            );
            collection.AddSingleton(sp =>
            {
                var config = sp.GetRequiredService<IOptions<KafkaClientConfig>>();
                var logger = sp.GetRequiredService<ILogger<IKafkaClient>>();
                return KafkaClientBuilder
                    .New()
                    .WithConfig(config.Value)
                    .WithLogger(logger)
                    .Build()
                ;
            });
            return collection;
        }

        public static IServiceCollection AddKafkaStreamWriter<TKey, TValue>(
            this IServiceCollection collection,
            string topic,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer
        )
        {
            collection.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IKafkaClient>();
                var logger = sp.GetRequiredService<ILogger<IOutputStream>>();
                var stream = client.CreateOutputStream()
                    .WithLogger(logger)
                    .Build()
                ;
                return stream
                    .CreateWriter(topic)
                    .WithKey(keySerializer)
                    .WithValue(valueSerializer)
                    .WithLogger(logger)
                    .Build()
                ;
            });
            return collection;
        }

        public static IServiceCollection AddKafkaStreamReader<TKey, TValue>(
            this IServiceCollection collection,
            string topic,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            collection.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IKafkaClient>();
                var logger = sp.GetRequiredService<ILogger<IApplicationInputStream>>();
                var stream = client.CreateInputStream()
                    .AsApplication(topic)
                    .WithLogger(logger)
                    .Build();
                ;
                return stream
                    .CreateReader()
                    .WithKey(keyDeserializer)
                    .WithValue(valueDeserializer)
                    .WithLogger(logger)
                    .Build()
                ;
            });
            return collection;
        }

        private static void Configure(
            KafkaClientConfig config,
            IConfiguration configuration,
            string configSection,
            IReadOnlyDictionary<string, PropertyInfo> properties
        )
        {
            var clientSection = configuration.GetSection(configSection);
            foreach (var item in clientSection.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config, property, item.Value);
            }

            var producerSection = clientSection.GetSection("Producer");
            foreach (var item in producerSection.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config.Producer, property, item.Value);
            }

            var consumerSection = clientSection.GetSection("Consumer");
            foreach (var item in consumerSection.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config.Consumer, property, item.Value);
            }
        }

        private static bool ApplyProperty(
            object instance,
            PropertyInfo propertyInfo,
            string? value
        )
        {
            var type = propertyInfo.PropertyType;
            if (type.Equals(typeof(string)))
                propertyInfo.SetValue(instance, value);
            else if (type.Equals(typeof(bool)) && bool.TryParse(value, out var boolValue))
                propertyInfo.SetValue(instance, boolValue);
            else if (type.Equals(typeof(int)) && int.TryParse(value, out var intValue))
                propertyInfo.SetValue(instance, intValue);
            else if (type.Equals(typeof(long)) && long.TryParse(value, out var longValue))
                propertyInfo.SetValue(instance, longValue);
            else if (type.IsEnum && Enum.TryParse(type, value, true, out var enumValue))
                propertyInfo.SetValue(instance, enumValue);
            else
                return false;
            return true;
        }

        private static IReadOnlyDictionary<string, PropertyInfo> MapProperties()
        {
            var properties = typeof(KafkaClientConfig)
                .GetProperties()
                .Concat(typeof(InputStreamConfig).GetProperties())
                .Concat(typeof(OutputStreamConfig).GetProperties())
                .Select(r => new { Name = r.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? "", Property = r })
                .Where(r => r.Name != "")
                .ToImmutableSortedDictionary(
                    k => k.Name,
                    v => v.Property
                )
            ;
            return properties;
        }
    }
}