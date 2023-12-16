using Kafka.Client.Model.Internal;

namespace Kafka.Client.Net
{
    internal delegate ApiErrorsReturnValue ApiErrorDelegate<TResponse>(in TResponse response);
}
