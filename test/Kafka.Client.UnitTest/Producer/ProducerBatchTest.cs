using Kafka.Client.IO.Stream;
using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.UnitTest.Producer
{
    /// <summary>
    /// The V2 Records:
    /// ---------------
    /// baseOffset: int64
    /// batchLength: int32
    /// partitionLeaderEpoch: int32
    /// magic: int8(current magic value is 2)
    /// crc: int32
    /// attributes: int16
    ///     bit 0~2:
    ///         0: no compression
    ///         1: gzip
    ///         2: snappy
    ///         3: lz4
    ///         4: zstd
    ///     bit 3: timestampType
    ///     bit 4: isTransactional(0 means not transactional)
    ///     bit 5: isControlBatch(0 means not a control batch)
    ///     bit 6: hasDeleteHorizonMs(0 means baseTimestamp is not set as the delete horizon for compaction)
    ///     bit 7~15: unused
    /// lastOffsetDelta: int32
    /// baseTimestamp: int64
    /// maxTimestamp: int64
    /// producerId: int64
    /// producerEpoch: int16
    /// baseSequence: int32
    /// records: [Record]
    /// 
    /// Things to know when testing:
    /// - The record empty batch takes up 61 bytes
    /// - An easily overlooked detail is that the batchLength contains the length of the Records + the length of the Records array as a variable length int.
    /// 
    /// 
    /// The V2 Record:
    /// --------------
    /// length: varint
    /// attributes: int8
    ///     bit 0~7: unused
    /// timestampDelta: varlong
    /// offsetDelta: varint
    /// keyLength: varint
    /// key: byte[]
    /// valueLen: varint
    /// value: byte[]
    /// Headers => [Header]
    /// 
    /// The minumum length of a Record (key=null,value=null and header=empty) is 6 bytes.
    /// However sinse the record is encoded as a compact array the total bytes needed is 7 for length of the array.
    /// 
    /// The Record Header:
    /// ------------------
    /// headerKeyLength: varint
    /// headerKey: String
    /// headerValueLength: varint
    /// Value: byte[]
    /// 
    /// </summary>
    [TestFixture]
    public class ProducerBatchTest
    {
        [Test]
        public void TestInit()
        {
            var producerBatch = CreateBatch(
                1024
            );

            var expectedBatchSize = 0;
            Assert.That(
                producerBatch.BatchSize,
                Is.EqualTo(expectedBatchSize)
            );
        }

        [Test]
        public void TestMinSize()
        {
            var expectedSize =
                61 +    // Batch header size
                1 +     // Record compact array length
                6       // Record Byte count
            ;

            var producerBatch = CreateBatch(
                1024
            );

            var baseTimestamp = new Timestamp(
                TimestampType.CreateTime,
                0
            );

            var sendCommand = CreateSendCommand(
                0,
                baseTimestamp,
                Array.Empty<byte>(),
                Array.Empty<byte>()
            );

            (var added, var size) = producerBatch.Add(
                sendCommand
            );

            Assert.Multiple(() =>
            {
                Assert.That(
                    added,
                    Is.EqualTo(true)
                );

                Assert.That(
                    size,
                    Is.EqualTo(expectedSize)
                );

                Assert.That(
                    producerBatch.BatchSize,
                    Is.EqualTo(expectedSize)
                );
            });
        }

        [Test]
        public void TestMultipleRecordsMultiplePartitions()
        {
            var producerBatch = CreateBatch(
                1024
            );

            var baseTimestamp = new Timestamp(
                TimestampType.CreateTime,
                0
            );

            var topicPartitions = Enumerable
                .Range(0, 3)
                .Select(r => CreateSendCommand(
                    r,
                    baseTimestamp,
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            ).ToArray();

            var expectedSize =
                61 +    // Batch header size
                1 +     // Record compact array length
                6       // Record Byte count
            ;
            var expectedBatchSize = 0;
            foreach (var sendCommand in topicPartitions)
            {
                expectedBatchSize += expectedSize;

                (var added, var size) = producerBatch.Add(
                    sendCommand
                );

                Assert.Multiple(() =>
                {
                    Assert.That(
                        added,
                        Is.EqualTo(true)
                    );

                    Assert.That(
                        size,
                        Is.EqualTo(expectedSize)
                    );

                    Assert.That(
                        producerBatch.BatchSize,
                        Is.EqualTo(expectedBatchSize)
                    );
                });
            }
        }

        [Test]
        public void TestMultipleRecordsSamePartitions()
        {
            var producerBatch = CreateBatch(
                1024
            );

            var baseTimestamp = new Timestamp(
                TimestampType.CreateTime,
                0
            );

            var sendCommand = CreateSendCommand(
                0,
                baseTimestamp,
                Array.Empty<byte>(),
                Array.Empty<byte>()
            );

            var expectedBatchSize = 0;
            for (int i = 0; i < 3; i++)
            {
                var expectedSize =
                    (i == 0 ? 61 : 0) + // Batch header size (only first one)
                    1 +                 // Record compact array length
                    6                   // Record Byte count
                ;
                expectedBatchSize += expectedSize;

                (var added, var size) = producerBatch.Add(
                    sendCommand
                );

                Assert.Multiple(() =>
                {
                    Assert.That(
                        added,
                        Is.EqualTo(true)
                    );

                    Assert.That(
                        size,
                        Is.EqualTo(expectedSize)
                    );

                    Assert.That(
                        producerBatch.BatchSize,
                        Is.EqualTo(expectedBatchSize)
                    );
                });
            }
        }

        [Test]
        public void TestMultipleRecordsSamePartitionsOverflow()
        {
            var producerBatch = CreateBatch(
                196
            );

            var baseTimestamp = new Timestamp(
                TimestampType.CreateTime,
                0
            );

            var sendCommand = CreateSendCommand(
                0,
                baseTimestamp,
                new byte[] { 0x00, 0x01 },
                new byte[] { 0x00, 0x01, 0x02, 0x03,
                             0x04, 0x05, 0x06, 0x07,
                             0x08, 0x09, 0x0A, 0x0B,
                             0x0C, 0x0D, 0x0E, 0x0F },
                ("header", new byte[] { 0x00, 0xFF })
            );

            var expectedBatchSize = 0;
            for (int i = 0; i < 4; i++)
            {
                // The fourth should exceed capacity
                var expectedAdded = i < 3;
                // First one will include header size.
                var expectedSize =
                    (i == 0 ? 61 : 0) +
                    35
                ;
                // Batch should increase except for fourth attempt where it should stay the same.
                expectedBatchSize += (i < 3) ? expectedSize : 0;

                (var added, var size) = producerBatch.Add(
                    sendCommand
                );

                Assert.Multiple(() =>
                {
                    Assert.That(
                        added,
                        Is.EqualTo(expectedAdded)
                    );

                    Assert.That(
                        size,
                        Is.EqualTo(expectedSize)
                    );

                    Assert.That(
                        producerBatch.BatchSize,
                        Is.EqualTo(expectedBatchSize)
                    );
                });
            }
        }


        private static ProduceCommand CreateSendCommand(
            int partition,
            Timestamp timestamp,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value
        ) =>
            new(
                new(
                    new TopicPartition(new Topic(Guid.Empty, "test"), partition),
                    timestamp,
                    key,
                    value,
                    ImmutableArray<RecordHeader>.Empty,
                    Attributes.None
                ),
                new TaskCompletionSource<ProduceResult>()
            )
        ;

        private static ProduceCommand CreateSendCommand(
            int partition,
            Timestamp timestamp,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
            params (string, byte[])[] headers
        ) =>
            new(
                new(
                    new TopicPartition(new Topic(Guid.Empty, "test"), partition),
                    timestamp,
                    key,
                    value,
                    headers.Select(r => new RecordHeader(r.Item1, r.Item2)).ToImmutableArray(),
                    Attributes.None
                ),
                new TaskCompletionSource<ProduceResult>()
            )
        ;

        private static ProduceBatch CreateBatch(
            int size
        ) =>
            new(
                size,
                0,
                Attributes.None,
                0,
                0
            )
        ;
    }
}
