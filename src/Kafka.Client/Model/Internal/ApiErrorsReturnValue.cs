using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model.Internal
{
    internal readonly record struct ApiErrorsReturnValue(
        bool IsTransient,
        ImmutableArray<ApiError> ApiErrors
    )
    {
        public static implicit operator ApiErrorsReturnValue(
            (bool IsTransient, ImmutableArray<ApiError> ApiErrors) value
        ) => new(value.IsTransient, value.ApiErrors);
    }
}
