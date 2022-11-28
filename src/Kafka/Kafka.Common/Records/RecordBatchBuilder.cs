using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public interface IRecordBatchBuilder
    {
        IRecords Build();
    }

    public sealed class RecordBatchBuilder :
        IRecordBatchBuilder
    {
        private readonly sbyte _magic = 2;

        private long _baseOffset = 0;
        private int _batchLength = 0;
        private int _partitionLeaderEpoch = 0;
        private Attributes Attributes = Attributes.None;
        private int LastOffsetDelta = 0;
        private long BaseTimestamp = 0;
        private long MaxTimestamp = 0;
        private long ProducerId = 0;
        private short ProducerEpoch = 0;
        private int BaseSequence = 0;
        private ImmutableArray<IRecord>.Builder _recordBuilder = ImmutableArray.CreateBuilder<IRecord>();

        private RecordBatchBuilder() { }

        public static IRecordBatchBuilder New() => new RecordBatchBuilder();

        IRecords IRecordBatchBuilder.Build()
        {

            throw new NotImplementedException();
        }
    }
}
