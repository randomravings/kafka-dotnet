using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeConfigsResponse (
        int ThrottleTimeMsField,
        DescribeConfigsResponse.DescribeConfigsResult[] ResultsField
    )
    {
        public sealed record DescribeConfigsResult (
            short ErrorCodeField,
            string ErrorMessageField,
            sbyte ResourceTypeField,
            string ResourceNameField,
            DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult[] ConfigsField
        )
        {
            public sealed record DescribeConfigsResourceResult (
                string NameField,
                string ValueField,
                bool ReadOnlyField,
                bool IsDefaultField,
                sbyte ConfigSourceField,
                bool IsSensitiveField,
                DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult.DescribeConfigsSynonym[] SynonymsField,
                sbyte ConfigTypeField,
                string DocumentationField
            )
            {
                public sealed record DescribeConfigsSynonym (
                    string NameField,
                    string ValueField,
                    sbyte SourceField
                );
            };
        };
    };
}
