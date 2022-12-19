using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public interface IRecordsBuilder
    {
        IRecords Build();
    }

    public interface IMessagesBuilderV0
    {
        IMessagesBuilderV0 AddMessage(
            
        );
        IRecords Build();
    }

    public interface IMessagesBuilderV1
    {
        IMessagesBuilderV0 AddMessage(

        );
        IRecords Build();
    }

    public sealed class RecordsBuilder :
        IRecordsBuilder
    {
        private readonly sbyte _magic = 2;
        private long _baseOffset = 0;
        private int _batchLength = 0;
        private int _partitionLeaderEpoch = 0;
        private Attributes _attributes = Attributes.None;
        private int _lastOffsetDelta = 0;
        private long _baseTimestamp = 0;
        private long _maxTimestamp = 0;
        private long _producerId = 0;
        private short _producerEpoch = 0;
        private int _baseSequence = 0;
        private ImmutableArray<IRecord>.Builder _records = ImmutableArray.CreateBuilder<IRecord>();

        private RecordsBuilder() { }

        public static IRecordsBuilder New() => new RecordsBuilder();

        IRecords IRecordsBuilder.Build()
        {

            return new RecordBatch(
                _baseOffset,
                _batchLength,
                _partitionLeaderEpoch,
                _magic,
                0,
                _attributes,
                _lastOffsetDelta,
                _baseTimestamp,
                _maxTimestamp,
                _producerId,
                _producerEpoch,
                _baseSequence,
                _records.ToImmutable()
            );
        }
    }
}
