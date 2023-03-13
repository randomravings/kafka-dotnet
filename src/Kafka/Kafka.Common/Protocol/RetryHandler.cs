using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Microsoft.Extensions.Logging;

namespace Kafka.Common.Protocol
{
    public static class RetryHandler
    {
        public static async Task<TResponse> Run<TRequest, TResponse>(
            IConnection connection,
            TRequest request,
            EncodeVersionDelegate<TRequest> requestWriter,
            DecodeVersionDelegate<TResponse> responseReader,
            int retries,
            long retryBackoffMs,
            Func<TResponse, short> errorCheck,
            Action<ILogger, Error> errorLogger,
            ILogger logger,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, Request
            where TResponse : notnull, Response
        {
            var taskCompletionSource = new TaskCompletionSource<TResponse>();
            var retryCount = 0;
            var retryBackoff = TimeSpan.FromSeconds(retryBackoffMs);
            var lastError = Errors.Known.NONE;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var response = await connection.ExecuteRequest(
                        request,
                        requestWriter,
                        responseReader,
                        cancellationToken
                    );
                    var errorCode = errorCheck(response);
                    if (errorCode == 0)
                    {
                        taskCompletionSource.SetResult(response);
                        return await taskCompletionSource.Task;
                    }
                    lastError = Errors.Translate(errorCode);
                    errorLogger(logger, lastError);
                    retryCount++;
                    if (lastError.Retriable && (retries < 1 || retryCount < retries))
                        cancellationToken.WaitHandle.WaitOne(retryBackoff);
                    else
                        break;
                }
                taskCompletionSource.SetException(new ApiException(lastError));
            }
            catch (Exception ex)
            {
                taskCompletionSource.SetException(ex);
            }
            return await taskCompletionSource.Task;
        }
    }
}
