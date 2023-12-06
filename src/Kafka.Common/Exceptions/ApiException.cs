using Kafka.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Exceptions
{
    public class ApiException(
        [DisallowNull] ApiError error
    ) : Exception(error.Message)
    {
        public ApiError Error { get; init; } = error;
    }
}
