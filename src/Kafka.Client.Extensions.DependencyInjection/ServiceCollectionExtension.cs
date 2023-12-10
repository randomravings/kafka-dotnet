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
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer
        )
        {
            collection.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IKafkaClient>();
                var logger = sp.GetRequiredService<ILogger<IWriteStream>>();
                var stream = client.CreateWriteStream()
                    .WithLogger(logger)
                    .Build()
                ;
                return stream
                    .CreateWriter()
                    .WithLogger(logger)
                    .WithKey(keySerializer)
                    .WithValue(valueSerializer)
                    .Build()
                ;
            });
            return collection;
        }

        public static IServiceCollection AddKafkaStreamReader<TKey, TValue>(
            this IServiceCollection collection,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            collection.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IKafkaClient>();
                var logger = sp.GetRequiredService<ILogger<IGroupReadStream>>();
                var stream = client.CreateReadStream()
                    .WithLogger(logger)
                    .AsApplication()
                    .Build();
                ;
                return stream
                    .CreateReader()
                    .WithLogger(logger)
                    .WithKey(keyDeserializer)
                    .WithValue(valueDeserializer)
                    .Build()
                ;
            });
            return collection;
        }

        private static void Configure(
            KafkaClientConfig config,
            IConfiguration configuration,
            string configSection,
            ImmutableSortedDictionary<string, PropertyInfo> properties
        )
        {
            var section = configuration.GetSection(configSection);
            foreach (var item in section.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config, property, item.Value);
            }

            var clientSection = section.GetSection(nameof(KafkaClientConfig.Client));
            foreach (var item in clientSection.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config.Client, property, item.Value);
            }

            var writeStreamSection = section.GetSection(nameof(KafkaClientConfig.WriteStream));
            foreach (var item in writeStreamSection.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config.WriteStream, property, item.Value);
            }

            var readStreamSection = section.GetSection(nameof(KafkaClientConfig.ReadStream));
            foreach (var item in readStreamSection.GetChildren())
            {
                if (properties.TryGetValue(item.Key, out var property))
                    ApplyProperty(config.ReadStream, property, item.Value);
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

        private static ImmutableSortedDictionary<string, PropertyInfo> MapProperties()
        {
            var properties = typeof(KafkaClientConfig)
                .GetProperties()
                .Concat(typeof(ClientConfig).GetProperties())
                .Concat(typeof(ReadStreamConfig).GetProperties())
                .Concat(typeof(WriteStreamConfig).GetProperties())
                .Select(r => new { Name = r.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? "", Property = r })
                .Where(r => !string.IsNullOrEmpty(r.Name))
                .ToImmutableSortedDictionary(
                    k => k.Name,
                    v => v.Property
                )
            ;
            return properties;
        }
    }
}