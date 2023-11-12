using Kafka.Client.Clients;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Kafka.Cli.Options
{
    public static class OptionsMapper
    {
        public static bool SetProperties<TConfig>(
            TConfig clientConfig,
            IEnumerable<string> strings,
            TextWriter output
        ) =>
            CreatePropertyDictionary(strings, output, out var properties) &&
            ApplyProperties(clientConfig, properties, output)
        ;

        private static bool CreatePropertyDictionary(
            IEnumerable<string> strings,
            TextWriter output,
            out IReadOnlyDictionary<string, string?> properties
        )
        {
            properties = ImmutableDictionary<string, string?>.Empty;
            var splits = strings.Select(r =>
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

        private static bool ApplyProperties<TConfig>(
            TConfig clientConfig,
            IReadOnlyDictionary<string, string?> properties,
            TextWriter output
        )
        {
            var success = true;
            var propertyInfos = MapProperties<TConfig>();
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

        private static bool ApplyProperty<TConfig>(
            TConfig clientConfig,
            PropertyInfo propertyInfo,
            string? value
        )
        {
            var type = propertyInfo.PropertyType;
            if (type.Equals(typeof(string)))
                propertyInfo.SetValue(clientConfig, value);
            else if (type.Equals(typeof(bool)) && bool.TryParse(value, out var boolValue))
                propertyInfo.SetValue(clientConfig, boolValue);
            else if (type.Equals(typeof(int)) && int.TryParse(value, out var intValue))
                propertyInfo.SetValue(clientConfig, intValue);
            else if (type.Equals(typeof(long)) && long.TryParse(value, out var longValue))
                propertyInfo.SetValue(clientConfig, longValue);
            else if (type.IsEnum && Enum.TryParse(type, value, true, out var enumValue))
                propertyInfo.SetValue(clientConfig, enumValue);
            else
                return false;
            return true;
        }

        private static IReadOnlyDictionary<string, PropertyInfo> MapProperties<TConfig>()
        {
            var type = typeof(TConfig);
            var properties = type
                .GetProperties()
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
