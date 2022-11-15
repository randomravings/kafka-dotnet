﻿using Kafka.Common.Encoding;

namespace Kafka.Common.UnitTest.Encoding
{
    [TestFixture]
    public class EncoderTest
    {
        [TestCase(false, new byte[] { 0x00 })]
        [TestCase(true, new byte[] { 0x01 })]
        public void TestWriteBoolean(bool value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteBoolean(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(1L));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..1]);
        }

        [TestCase(0, new byte[] { 0x00 })]
        [TestCase(1, new byte[] { 0x01 })]
        [TestCase(-1, new byte[] { 0xFF })]
        [TestCase(sbyte.MaxValue, new byte[] { 0x7F })]
        [TestCase(sbyte.MinValue, new byte[] { 0x80 })]
        public void TestWriteInt8(sbyte value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteInt8(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(1L));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..1]);
        }

        [TestCase(0, new byte[] { 0x00, 0x00 })]
        [TestCase(1, new byte[] { 0x00, 0x01 })]
        [TestCase(-1, new byte[] { 0xFF, 0xFF })]
        [TestCase(sbyte.MaxValue, new byte[] { 0x00, 0x7F })]
        [TestCase(sbyte.MinValue, new byte[] { 0xFF, 0x80 })]
        [TestCase(128, new byte[] { 0x00, 0x80 })]
        [TestCase(-129, new byte[] { 0xFF, 0x7F })]
        [TestCase(short.MaxValue, new byte[] { 0x7F, 0xFF })]
        [TestCase(short.MinValue, new byte[] { 0x80, 0x00 })]
        public void TestWriteInt16(short value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteInt16(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(2L));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..2]);
        }

        [TestCase(0, new byte[] { 0x00, 0x00, 0x00, 0x00 })]
        [TestCase(1, new byte[] { 0x00, 0x00, 0x00, 0x01 })]
        [TestCase(-1, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF })]
        [TestCase(sbyte.MaxValue, new byte[] { 0x00, 0x00, 0x00, 0x7F })]
        [TestCase(sbyte.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0x80 })]
        [TestCase(128, new byte[] { 0x00, 0x00, 0x00, 0x80 })]
        [TestCase(-129, new byte[] { 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(short.MaxValue, new byte[] { 0x00, 0x00, 0x7F, 0xFF })]
        [TestCase(short.MinValue, new byte[] { 0xFF, 0xFF, 0x80, 0x00 })]
        [TestCase(32768, new byte[] { 0x00, 0x00, 0x80, 0x00 })]
        [TestCase(-32769, new byte[] { 0xFF, 0xFF, 0x7F, 0xFF })]
        [TestCase(int.MaxValue, new byte[] { 0x7F, 0xFF, 0xFF, 0xFF })]
        [TestCase(int.MinValue, new byte[] { 0x80, 0x00, 0x00, 0x00 })]
        public void TestWriteInt32(int value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteInt32(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(4L));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..4]);
        }

        [TestCase(0U, new byte[] { 0x00, 0x00, 0x00, 0x00 })]
        [TestCase(1U, new byte[] { 0x00, 0x00, 0x00, 0x01 })]
        [TestCase(2U, new byte[] { 0x00, 0x00, 0x00, 0x02 })]
        [TestCase(byte.MaxValue, new byte[] { 0x00, 0x00, 0x00, 0xFF })]
        [TestCase(256U, new byte[] { 0x00, 0x00, 0x01, 0x00 })]
        [TestCase(32767U, new byte[] { 0x00, 0x00, 0x7F, 0xFF })]
        [TestCase(ushort.MaxValue, new byte[] { 0x00, 0x00, 0xFF, 0xFF })]
        [TestCase(65536U, new byte[] { 0x00, 0x01, 0x00, 0x00 })]
        [TestCase(uint.MaxValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF })]
        public void TestWriteUInt32(uint value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteUInt32(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(4L));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..4]);
        }

        [TestCase(0, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })]
        [TestCase(1, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 })]
        [TestCase(-1, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF })]
        [TestCase(sbyte.MaxValue, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F })]
        [TestCase(sbyte.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80 })]
        [TestCase(128, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 })]
        [TestCase(-129, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(short.MaxValue, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF })]
        [TestCase(short.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00 })]
        [TestCase(32768, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00 })]
        [TestCase(-32769, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF })]
        [TestCase(int.MaxValue, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF })]
        [TestCase(int.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00 })]
        [TestCase(2147483648, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00 })]
        [TestCase(-2147483649, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF })]
        [TestCase(long.MaxValue, new byte[] { 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF })]
        [TestCase(long.MinValue, new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })]
        public void TestWriteInt64(long value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteInt64(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(8L));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..8]);
        }

        [TestCase(0, new byte[] { 0x00 })]
        [TestCase(-1, new byte[] { 0x01 })]
        [TestCase(1, new byte[] { 0x02 })]
        [TestCase(63, new byte[] { 0x7E })]
        [TestCase(-64, new byte[] { 0x7F })]
        [TestCase(64, new byte[] { 0x80, 0x01 })]
        [TestCase(-65, new byte[] { 0x81, 0x01 })]
        [TestCase(8191, new byte[] { 0xFE, 0x7F })]
        [TestCase(-8192, new byte[] { 0xFF, 0x7F })]
        [TestCase(8192, new byte[] { 0x80, 0x80, 0x01 })]
        [TestCase(-8193, new byte[] { 0x81, 0x80, 0x01 })]
        [TestCase(1048575, new byte[] { 0xFE, 0xFF, 0x7F })]
        [TestCase(-1048576, new byte[] { 0xFF, 0xFF, 0x7F })]
        [TestCase(1048576, new byte[] { 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-1048577, new byte[] { 0x81, 0x80, 0x80, 0x01 })]
        [TestCase(134217727, new byte[] { 0xFE, 0xFF, 0xFF, 0x7F })]
        [TestCase(-134217728, new byte[] { 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(134217728, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-134217729, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(int.MaxValue, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x0F })]
        [TestCase(int.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x0F })]
        public void TestWriteVarInt32(int value, byte[] expected)
        {
            var sizeOf = Encoder.SizeOfInt32(value);
            Assert.That(sizeOf, Is.EqualTo(expected.Length));

            using var buf = new MemoryStream();
            Encoder.WriteVarInt32(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(0U, new byte[] { 0x00 })]
        [TestCase(1U, new byte[] { 0x01 })]
        [TestCase(2U, new byte[] { 0x02 })]
        [TestCase(3U, new byte[] { 0x03 })]
        [TestCase(127U, new byte[] { 0x7F })]
        [TestCase(128U, new byte[] { 0x80, 0x01 })]
        [TestCase(129U, new byte[] { 0x81, 0x01 })]
        [TestCase(255U, new byte[] { 0xFF, 0x01 })]
        [TestCase(256U, new byte[] { 0x80, 0x02 })]
        [TestCase(257U, new byte[] { 0x81, 0x02 })]
        [TestCase(511U, new byte[] { 0xFF, 0x03 })]
        [TestCase(512U, new byte[] { 0x80, 0x04 })]
        [TestCase(513U, new byte[] { 0x81, 0x04 })]
        [TestCase(1023U, new byte[] { 0xFF, 0x07 })]
        [TestCase(1024U, new byte[] { 0x80, 0x08 })]
        [TestCase(1025U, new byte[] { 0x81, 0x08 })]
        [TestCase(8191U, new byte[] { 0xFF, 0x3F })]
        [TestCase(8192U, new byte[] { 0x80, 0x40 })]
        [TestCase(8193U, new byte[] { 0x81, 0x40 })]
        [TestCase(1048575U, new byte[] { 0xFF, 0xFF, 0x3F })]
        [TestCase(1048576U, new byte[] { 0x80, 0x80, 0x40 })]
        [TestCase(1048577U, new byte[] { 0x81, 0x80, 0x40 })]
        [TestCase(134217727U, new byte[] { 0xFF, 0xFF, 0xFF, 0x3F })]
        [TestCase(134217728U, new byte[] { 0x80, 0x80, 0x80, 0x40 })]
        [TestCase(134217729U, new byte[] { 0x81, 0x80, 0x80, 0x40 })]
        [TestCase(2147483646U, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x07 })]
        [TestCase(2147483647U, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x07 })]
        [TestCase(2147483648U, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x08 })]
        [TestCase(4294967294U, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x0F })]
        [TestCase(4294967295U, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x0F })]
        public void TestWriteVarUInt32(uint value, byte[] expected)
        {
            var sizeOf = Encoder.SizeOfUInt32(value);
            Assert.That(sizeOf, Is.EqualTo(expected.Length));

            using var buf = new MemoryStream();
            Encoder.WriteVarUInt32(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(0, new byte[] { 0x00 })]
        [TestCase(-1, new byte[] { 0x01 })]
        [TestCase(1, new byte[] { 0x02 })]
        [TestCase(63, new byte[] { 0x7E })]
        [TestCase(-64, new byte[] { 0x7F })]
        [TestCase(64, new byte[] { 0x80, 0x01 })]
        [TestCase(-65, new byte[] { 0x81, 0x01 })]
        [TestCase(8191, new byte[] { 0xFE, 0x7F })]
        [TestCase(-8192, new byte[] { 0xFF, 0x7F })]
        [TestCase(8192, new byte[] { 0x80, 0x80, 0x01 })]
        [TestCase(-8193, new byte[] { 0x81, 0x80, 0x01 })]
        [TestCase(1048575, new byte[] { 0xFE, 0xFF, 0x7F })]
        [TestCase(-1048576, new byte[] { 0xFF, 0xFF, 0x7F })]
        [TestCase(1048576, new byte[] { 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-1048577, new byte[] { 0x81, 0x80, 0x80, 0x01 })]
        [TestCase(134217727, new byte[] { 0xFE, 0xFF, 0xFF, 0x7F })]
        [TestCase(-134217728, new byte[] { 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(134217728, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-134217729, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(int.MaxValue, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x0F })]
        [TestCase(int.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x0F })]
        [TestCase(17179869183L, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(-17179869184L, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(17179869184L, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-17179869185L, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(2199023255551L, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(-2199023255552L, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(2199023255552L, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-2199023255553L, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(281474976710655L, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(-281474976710656L, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(281474976710656L, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-281474976710657L, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 1 })]
        [TestCase(36028797018963967L, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(-36028797018963968L, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(36028797018963968L, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-36028797018963969L, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(4611686018427387903L, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(-4611686018427387904L, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F })]
        [TestCase(4611686018427387904L, new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(-4611686018427387905L, new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 })]
        [TestCase(long.MaxValue, new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x01 })]
        [TestCase(long.MinValue, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x01 })]
        public void TestWriteVarInt64(long value, byte[] expected)
        {
            var sizeOf = Encoder.SizeOfInt64(value);
            Assert.That(sizeOf, Is.EqualTo(expected.Length));

            using var buf = new MemoryStream();
            Encoder.WriteVarInt64(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase("00000000-0000-0000-0000-000000000000", new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })]
        [TestCase("aba95cea-45d4-4621-9939-758d976353b5", new byte[] { 0xEA, 0x5C, 0xA9, 0xAB, 0xD4, 0x45, 0x21, 0x46, 0x99, 0x39, 0x75, 0x8D, 0x97, 0x63, 0x53, 0xB5 })]
        [TestCase("ffffffff-ffff-ffff-ffff-ffffffffffff", new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF })]
        public void TestWriteUUID(string value, byte[] expected)
        {
            Assert.That(Guid.TryParse(value, out var valueUuid), Is.True);
            using var buf = new MemoryStream();
            Encoder.WriteUuid(buf, valueUuid);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(0D, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 })]
        [TestCase(-89734587324924357.089734508973244D, new byte[] { 0xC3, 0x73, 0xEC, 0xD2, 0x1B, 0x99, 0x18, 0x1C })]
        [TestCase(9.12e12F, new byte[] { 0x42, 0xA0, 0x96, 0xD4, 0xC0, 0x00, 0x00, 0x00 })]
        [TestCase(double.MinValue, new byte[] { 0xFF, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF })]
        [TestCase(double.MaxValue, new byte[] { 0x7F, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF })]
        public void TestWriteFloat64(double value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteFloat64(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase("", new byte[] { 0x00, 0x00 })]
        [TestCase("A", new byte[] { 0x00, 0x01, 0x41 })]
        [TestCase("a", new byte[] { 0x00, 0x01, 0x61 })]
        [TestCase("a", new byte[] { 0x00, 0x01, 0x61 })]
        [TestCase("Hello World!", new byte[] { 0x00, 0x0C, 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64, 0x21 })]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", new byte[] { 0x00, 0x1A, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A })]
        [TestCase("zyxwvutsrqponmlkjihgfedcba", new byte[] { 0x00, 0x1A, 0x7A, 0x79, 0x78, 0x77, 0x76, 0x75, 0x74, 0x73, 0x72, 0x71, 0x70, 0x6F, 0x6E, 0x6D, 0x6C, 0x6B, 0x6A, 0x69, 0x68, 0x67, 0x66, 0x65, 0x64, 0x63, 0x62, 0x61 })]
        [TestCase(" !#$%&'()*+,-./0123456789:;<=>?@", new byte[] { 0x00, 0x20, 0x20, 0x21, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40 })]
        public void TestWriteString(string value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteString(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase("", new byte[] { 0x00 })]
        [TestCase("A", new byte[] { 0x01, 0x41 })]
        [TestCase("a", new byte[] { 0x01, 0x61 })]
        [TestCase("a", new byte[] { 0x01, 0x61 })]
        [TestCase("Hello World!", new byte[] { 0x0C, 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64, 0x21 })]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", new byte[] { 0x1A, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A })]
        [TestCase("zyxwvutsrqponmlkjihgfedcba", new byte[] { 0x1A, 0x7A, 0x79, 0x78, 0x77, 0x76, 0x75, 0x74, 0x73, 0x72, 0x71, 0x70, 0x6F, 0x6E, 0x6D, 0x6C, 0x6B, 0x6A, 0x69, 0x68, 0x67, 0x66, 0x65, 0x64, 0x63, 0x62, 0x61 })]
        [TestCase(" !#$%&'()*+,-./0123456789:;<=>?@", new byte[] { 0x20, 0x20, 0x21, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40 })]
        public void TestWriteCompactString(string value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteCompactString(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(null, new byte[] { 0xFF, 0xFF })]
        [TestCase("", new byte[] { 0x00, 0x00 })]
        [TestCase("A", new byte[] { 0x00, 0x01, 0x41 })]
        [TestCase("a", new byte[] { 0x00, 0x01, 0x61 })]
        [TestCase("a", new byte[] { 0x00, 0x01, 0x61 })]
        [TestCase("Hello World!", new byte[] { 0x00, 0x0C, 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64, 0x21 })]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", new byte[] { 0x00, 0x1A, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A })]
        [TestCase("zyxwvutsrqponmlkjihgfedcba", new byte[] { 0x00, 0x1A, 0x7A, 0x79, 0x78, 0x77, 0x76, 0x75, 0x74, 0x73, 0x72, 0x71, 0x70, 0x6F, 0x6E, 0x6D, 0x6C, 0x6B, 0x6A, 0x69, 0x68, 0x67, 0x66, 0x65, 0x64, 0x63, 0x62, 0x61 })]
        [TestCase(" !#$%&'()*+,-./0123456789:;<=>?@", new byte[] { 0x00, 0x20, 0x20, 0x21, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40 })]
        public void TestWriteNullableString(string? value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteNullableString(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(null, new byte[] { 0x00 })]
        [TestCase("", new byte[] { 0x00 })]
        [TestCase("A", new byte[] { 0x01, 0x41 })]
        [TestCase("a", new byte[] { 0x01, 0x61 })]
        [TestCase("a", new byte[] { 0x01, 0x61 })]
        [TestCase("Hello World!", new byte[] { 0x0C, 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64, 0x21 })]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", new byte[] { 0x1A, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A })]
        [TestCase("zyxwvutsrqponmlkjihgfedcba", new byte[] { 0x1A, 0x7A, 0x79, 0x78, 0x77, 0x76, 0x75, 0x74, 0x73, 0x72, 0x71, 0x70, 0x6F, 0x6E, 0x6D, 0x6C, 0x6B, 0x6A, 0x69, 0x68, 0x67, 0x66, 0x65, 0x64, 0x63, 0x62, 0x61 })]
        [TestCase(" !#$%&'()*+,-./0123456789:;<=>?@", new byte[] { 0x20, 0x20, 0x21, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40 })]
        public void TestWriteCompactNullableString(string? value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteCompactNullableString(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(new byte[] { }, new byte[] { 0x00, 0x00, 0x00, 0x00 })]
        [TestCase(new byte[] { 0x00 }, new byte[] { 0x00, 0x00, 0x00, 0x01, 0x00 })]
        [TestCase(new byte[] { 0x00, 0x1A }, new byte[] { 0x00, 0x00, 0x00, 0x02, 0x00, 0x1A })]
        public void TestWriteBytes(byte[] value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteBytes(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(new byte[] { }, new byte[] { 0x00 })]
        [TestCase(new byte[] { 0x00 }, new byte[] { 0x01, 0x00 })]
        [TestCase(new byte[] { 0x00, 0x1A }, new byte[] { 0x02, 0x00, 0x1A })]
        public void TestWriteCompactBytes(byte[] value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteCompactBytes(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(null, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF })]
        [TestCase(new byte[] { }, new byte[] { 0x00, 0x00, 0x00, 0x00 })]
        [TestCase(new byte[] { 0x00 }, new byte[] { 0x00, 0x00, 0x00, 0x01, 0x00 })]
        [TestCase(new byte[] { 0x00, 0x1A }, new byte[] { 0x00, 0x00, 0x00, 0x02, 0x00, 0x1A })]
        public void TestWriteNullableBytes(byte[]? value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteNullableBytes(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }

        [TestCase(null, new byte[] { 0x00 })]
        [TestCase(new byte[] { }, new byte[] { 0x00 })]
        [TestCase(new byte[] { 0x00 }, new byte[] { 0x01, 0x00 })]
        [TestCase(new byte[] { 0x00, 0x1A }, new byte[] { 0x02, 0x00, 0x1A })]
        public void TestWriteCompactNullableBytes(byte[]? value, byte[] expected)
        {
            using var buf = new MemoryStream();
            Encoder.WriteCompactNullableBytes(buf, value);
            buf.Flush();
            Assert.That(buf.Position, Is.EqualTo(expected.Length));
            CollectionAssert.AreEqual(expected, buf.GetBuffer()[0..expected.Length]);
        }
    }
}
