using Kafka.Cli.Options;
using Kafka.Client;
using Kafka.Client.Config;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Kafka.Cli.Client
{
    internal static class ClientUtils
    {
        internal static IKafkaClient CreateClient<TOpts>(
            TOpts opts,
            KafkaClientConfig config
        ) 
            where TOpts : notnull, Opts
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddSimpleConsole()
                    .SetMinimumLevel(opts.LogLevel)

                )
                .CreateLogger<IKafkaClient>()
            ;
            return KafkaClientBuilder
                .New()
                .WithConfig(config)
                .WithLogger(logger)
                .Build()
            ;
        }

        internal static bool TrySetProperties<TOpts>(
            KafkaClientConfig clientConfig,
            TOpts opts,
            TextWriter output
        )
            where TOpts : notnull, Opts
        {
            return CreatePropertyDictionary(opts, output, out var properties) &&
                ApplyProperties(clientConfig, properties, output)
            ;
        }

        private static bool CreatePropertyDictionary<TOpts>(
            TOpts opts,
            TextWriter output,
            out IReadOnlyDictionary<string, string?> properties
        )
            where TOpts : notnull, Opts
        {
            properties = ImmutableDictionary<string, string?>.Empty;
            var splits = opts.Properties.Select(r =>
            {
                var i = r.IndexOf('=');
                if (i < 1 || i == r.Length - 1)
                    return new string[] { r };
                else
                    return new[] { r[..i], r[(i + 1)..] };
            }).ToArray();

            var invalidKeyValues = splits.Where(r => r.Length != 2).ToArray();
            if (invalidKeyValues.Length > 0)
            {
                foreach (var kv in invalidKeyValues)
                    output.WriteLine($"Invalid property key value: '{kv}'");
                return false;
            }

            properties = splits.ToImmutableSortedDictionary(
                k => k[0],
                v => v[1] == "null" ? null : v[1]
            );
            return true;
        }

        private static bool ApplyProperties(
            KafkaClientConfig clientConfig,
            IReadOnlyDictionary<string, string?> properties,
            TextWriter output
        )
        {
            var success = true;
            var propertyInfos = MapProperties();
            foreach (var property in properties)
            {
                if (!propertyInfos.TryGetValue(property.Key, out var propertyInfo))
                {
                    output.WriteLine($"Unknown property: '{property.Key}'");
                    success = false;
                }
                else if (!ApplyProperty(clientConfig, propertyInfo, property.Value))
                {
                    output.WriteLine($"Unable to apply: '{property.Key}={property.Value}'");
                    success = false;
                }
            }
            return success;
        }

        private static bool ApplyProperty(
            KafkaClientConfig clientConfig,
            PropertyInfo propertyInfo,
            string? value
        )
        {
            var type = propertyInfo.PropertyType;
            var instance = propertyInfo.DeclaringType switch
            {
                null => default(object),
                Type t when t.Equals(typeof(ClientConfig)) => clientConfig.Client,
                Type t when t.Equals(typeof(InputStreamConfig)) => clientConfig.Consumer,
                Type t when t.Equals(typeof(OutputStreamConfig)) => clientConfig.Producer,
                _ => default
            };

            if (instance == null)
                return false;

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
                .Concat(typeof(ClientConfig).GetProperties())
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
