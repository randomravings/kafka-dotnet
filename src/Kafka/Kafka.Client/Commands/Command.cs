﻿namespace Kafka.Client.Commands
{
    internal abstract record Command<TResult>(
        TaskCompletionSource<TResult> TaskCompletionSource
    ) : ICommand<TResult>
    {
        async ValueTask<TResult> ICommand<TResult>.Result() =>
            await TaskCompletionSource.Task.ConfigureAwait(false)
        ;
    }
}