using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribeConfigsResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult;
using DescribeConfigsSynonym = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult.DescribeConfigsSynonym;
using DescribeConfigsResourceResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for each resource.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeConfigsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<DescribeConfigsResult> ResultsField
    ) : Response(32)
    {
        public static DescribeConfigsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<DescribeConfigsResult>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The error code, or 0 if we were able to successfully describe the configurations.</param>
        /// <param name="ErrorMessageField">The error message, or null if we were able to successfully describe the configurations.</param>
        /// <param name="ResourceTypeField">The resource type.</param>
        /// <param name="ResourceNameField">The resource name.</param>
        /// <param name="ConfigsField">Each listed configuration.</param>
        /// </summary>
        public sealed record DescribeConfigsResult (
            short ErrorCodeField,
            string? ErrorMessageField,
            sbyte ResourceTypeField,
            string ResourceNameField,
            ImmutableArray<DescribeConfigsResourceResult> ConfigsField
        )
        {
            public static DescribeConfigsResult Empty { get; } = new(
                default(short),
                default(string?),
                default(sbyte),
                "",
                ImmutableArray<DescribeConfigsResourceResult>.Empty
            );
            /// <summary>
            /// <param name="NameField">The configuration name.</param>
            /// <param name="ValueField">The configuration value.</param>
            /// <param name="ReadOnlyField">True if the configuration is read-only.</param>
            /// <param name="IsDefaultField">True if the configuration is not set.</param>
            /// <param name="ConfigSourceField">The configuration source.</param>
            /// <param name="IsSensitiveField">True if this configuration is sensitive.</param>
            /// <param name="SynonymsField">The synonyms for this configuration key.</param>
            /// <param name="ConfigTypeField">The configuration data type. Type can be one of the following values - BOOLEAN, STRING, INT, SHORT, LONG, DOUBLE, LIST, CLASS, PASSWORD</param>
            /// <param name="DocumentationField">The configuration documentation.</param>
            /// </summary>
            public sealed record DescribeConfigsResourceResult (
                string NameField,
                string? ValueField,
                bool ReadOnlyField,
                bool IsDefaultField,
                sbyte ConfigSourceField,
                bool IsSensitiveField,
                ImmutableArray<DescribeConfigsSynonym> SynonymsField,
                sbyte ConfigTypeField,
                string? DocumentationField
            )
            {
                public static DescribeConfigsResourceResult Empty { get; } = new(
                    "",
                    default(string?),
                    default(bool),
                    default(bool),
                    default(sbyte),
                    default(bool),
                    ImmutableArray<DescribeConfigsSynonym>.Empty,
                    default(sbyte),
                    default(string?)
                );
                /// <summary>
                /// <param name="NameField">The synonym name.</param>
                /// <param name="ValueField">The synonym value.</param>
                /// <param name="SourceField">The synonym source.</param>
                /// </summary>
                public sealed record DescribeConfigsSynonym (
                    string NameField,
                    string? ValueField,
                    sbyte SourceField
                )
                {
                    public static DescribeConfigsSynonym Empty { get; } = new(
                        "",
                        default(string?),
                        default(sbyte)
                    );
                };
            };
        };
    };
}