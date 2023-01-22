using Kafka.Common.Encoding;
using Kafka.Common.Hashing;
using System;
using System.Collections;
using System.Collections.Immutable;
using System.Reflection;

namespace Kafka.Common.Records
{
    internal sealed class RecordBatchBytes : IRecords
    {
        private readonly byte[] _data;
        private long? _offset;
        private int? _size;
        private int? _partitionLeaderEpoch;
        private sbyte? _magic;
        private int? _crc;
        private Attributes? _attributes;
        private int? _lastOffsetDelta;
        private long? _baseTimestamp;
        private long? _maxTimestamp;
        private long? _producerId;
        private short? _producerEpoch;
        private int? _baseSequence;
        private IRecord[]? _records;
        public RecordBatchBytes(byte[] bytes) =>
            _data = bytes;
        IRecord IReadOnlyList<IRecord>.this[int index] => GetRecords()[index];

        long IRecords.Offset => GetOffset();
        private long GetOffset()
        {
            if (_offset == null)
                (_, _offset) = Decoder.ReadInt64(_data, 0);
            return _offset.Value;
        }

        int IRecords.Size => GetSize();
        private int GetSize()
        {
            if (_size == null)
                (_, _size) = Decoder.ReadInt32(_data, 8);
            return _size.Value;
        }

        int IRecords.PartitionLeaderEpoch => GetPartitionLeaderEpoch();
        private int GetPartitionLeaderEpoch()
        {
            if (_partitionLeaderEpoch == null)
                (_, _partitionLeaderEpoch) = Decoder.ReadInt32(_data, 12);
            return _partitionLeaderEpoch.Value;
        }

        sbyte IRecords.Magic => GetMagic();
        private sbyte GetMagic()
        {
            if (_magic == null)
                (_, _magic) = Decoder.ReadInt8(_data, 13);
            return _magic.Value;
        }

        int IRecords.Crc => GetCrc();
        private int GetCrc()
        {
            if (_crc == null)
                (_, _crc) = Decoder.ReadInt32(_data, 17);
            return _crc.Value;
        }

        Attributes IRecords.Attributes => GetAttributes();
        private Attributes GetAttributes()
        {
            if (_attributes == null)
                (_, _attributes) = ((int, Attributes))Decoder.ReadInt16(_data, 21);
            return _attributes.Value;
        }

        int IRecords.LastOffsetDelta => GetLastOffsetDelta();
        private int GetLastOffsetDelta()
        {
            if (_lastOffsetDelta == null)
                (_, _lastOffsetDelta) = Decoder.ReadInt32(_data, 23);
            return _lastOffsetDelta.Value;
        }

        long IRecords.BaseTimestamp => GetBaseTimestamp();
        private long GetBaseTimestamp()
        {
            if (_baseTimestamp == null)
                (_, _baseTimestamp) = Decoder.ReadInt64(_data, 27);
            return _baseTimestamp.Value;
        }

        long IRecords.MaxTimestamp => GetMaxTimestamp();
        private long GetMaxTimestamp()
        {
            if (_maxTimestamp == null)
                (_, _maxTimestamp) = Decoder.ReadInt64(_data, 35);
            return _maxTimestamp.Value;
        }

        long IRecords.ProducerId => GetProducerId();
        private long GetProducerId()
        {
            if (_producerId == null)
                (_, _producerId) = Decoder.ReadInt64(_data, 43);
            return _producerId.Value;
        }

        short IRecords.ProducerEpoch => GetProducerEpoch();
        private short GetProducerEpoch()
        {
            if (_producerEpoch == null)
                (_, _producerEpoch) = Decoder.ReadInt16(_data, 51);
            return _producerEpoch.Value;
        }

        int IRecords.BaseSequence => GetBaseSequence();
        private int GetBaseSequence()
        {
            if (_baseSequence == null)
                (_, _baseSequence) = Decoder.ReadInt32(_data, 53);
            return _baseSequence.Value;
        }

        private IRecord[] GetRecords()
        {
            if (_records == null)
            {
                (var index, var count) = Decoder.ReadInt32(_data, 57);
                _records = new IRecord[count];
                for(int i = 0; i < count; i++)
                {
                    (var offset, var length) = Decoder.ReadInt32(_data, index);
                    _records[i] = new RecordRaw(_data, index, length);
                    index = offset;
                }
            }
            return _records;
        }

        CompressionType IRecords.CompressionType => (CompressionType)(GetAttributes() & Attributes.CompressionType);

        TimestampType IRecords.TimestampType => (TimestampType)(GetAttributes() & Attributes.TimestampType);

        bool IRecords.IsTransactional => GetAttributes().HasFlag(Attributes.IsTransactional);

        bool IRecords.IsControlBatch => GetAttributes().HasFlag(Attributes.IsControlBatch);

        bool IRecords.HasDeleteHorizonMs => GetAttributes().HasFlag(Attributes.HasDeleteHorizonMs);

        ControlRecord IRecords.ControlRecord => (ControlRecord)GetRecords()[0];

        int IReadOnlyCollection<IRecord>.Count => GetRecords().Length;

        void IRecords.EnsureValid()
        {
            var crc = Crc32c.Update(_data, 21, _data.Length - 21);
            var crcInt = unchecked((int)crc);
            var myCrc = GetCrc();
            if (crcInt != myCrc)
                throw new InvalidDataException("Crc check failed.");
        }

        IEnumerator<IRecord> IEnumerable<IRecord>.GetEnumerator()
        {
            foreach(var record in GetRecords())
                yield return record;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var record in GetRecords())
                yield return record;
        }

        private class RecordRaw :
            IRecord
        {
            private readonly byte[] _data;
            private readonly int _length;
            private readonly long _timestampDelta;
            private readonly int _offsetDelta;
            protected readonly ReadOnlyMemory<byte>? _key;
            protected readonly ReadOnlyMemory<byte>? _value;
            private readonly int _headerOffset;
            private ImmutableArray<RecordHeader>? _recordHeaders;

            public RecordRaw(byte[] data, int start, int length)
            {
                _data = data;
                _length = length;
                var index = start;
                (index, _timestampDelta) = Decoder.ReadVarInt64(data, index);
                (index, _offsetDelta) = Decoder.ReadVarInt32(data, index);
                (index, var keyLength) = Decoder.ReadVarInt32(data, index);
                if (keyLength >= 0)
                    _key = new ReadOnlyMemory<byte>(_data, index, keyLength);
                index += keyLength;
                (index, var valueLength) = Decoder.ReadVarInt32(_data, index);
                if (valueLength >= 0)
                    _value = new ReadOnlyMemory<byte>(_data, index, valueLength);
                _headerOffset = index;
            }

            int IRecord.Length => _length;
            Attributes IRecord.Attributes => Attributes.None;
            long IRecord.TimestampDelta => _timestampDelta;
            int IRecord.OffsetDelta => _offsetDelta;
            ReadOnlyMemory<byte>? IRecord.Key => _key;
            ReadOnlyMemory<byte>? IRecord.Value => _value;
            ImmutableArray<RecordHeader> IRecord.Headers => GetHeaders();
            private ImmutableArray<RecordHeader> GetHeaders()
            {
                if(_recordHeaders == null)
                {
                    _recordHeaders = ImmutableArray<RecordHeader>.Empty;
                    (var index, var headerCount) = Decoder.ReadVarInt32(_data, _headerOffset);
                    if (headerCount > 0)
                    {
                        var headersBuilder = ImmutableArray.CreateBuilder<RecordHeader>(headerCount);
                        for (int i = 0; i < headerCount; i++)
                        {
                            (index, var key) = Decoder.ReadCompactString(_data, index);
                            (index, var value) = Decoder.ReadCompactBytes(_data, index);
                            headersBuilder.Add(new(key, value));
                        }
                        _recordHeaders = headersBuilder.ToImmutable();
                    }
                }
                return _recordHeaders.Value;
            }
        }

        private sealed class ControlRecordRaw :
            RecordRaw
        {
            private readonly short _type;
            private readonly short _version;
            public ControlRecordRaw(byte[] data, int start, int length)
                : base(data, start, length)
            {
                if(_key == null)
                {
                    _type = 0;
                    _version = 0;
                }
                else
                {
                    var bytes = _key.Value.ToArray();
                    (_, _type) = Decoder.ReadInt16(bytes, 0);
                    (_, _version) = Decoder.ReadInt16(bytes, 2);
                }
            }
            public short Type => _type;
            public short Version => _version;
        }
    }
}
