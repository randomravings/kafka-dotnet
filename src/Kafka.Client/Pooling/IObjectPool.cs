using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Pooling
{
    public interface IObjectPool<TType>
    {
        int PoolSize { get; }
        bool TryAllocate(Func<TType> ininitalizer, [MaybeNullWhen(false)] out TType item);
        void Deallocate(in TType item);
        void Clear();
    }
}
