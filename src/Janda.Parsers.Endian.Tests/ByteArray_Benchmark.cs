using System;
using System.Buffers.Binary;
using System.Linq;
using Xunit;

namespace Janda.Parsers.Endian.Tests
{
    public class ByteArray_Benchmark
    {        
        [Fact]
        public void ByteArrayExtensions_ReadAsBigEndianToInt16_OneBillionTimes()
        {
            const int ONE_BILLION = 1000000000;
            var buffer = new byte[8];

            for (uint i = 0; i < ONE_BILLION; i++)
                buffer.ReadAsBigEndianToInt16(0);
        }

        [Fact]
        public void BinaryPrimitives_ReadInt16BigEndian_OneBillionTimes()
        {
            const int ONE_BILLION = 1000000000;
            var buffer = new byte[8];

            for (uint i = 0; i < ONE_BILLION; i++)
                BinaryPrimitives.ReadInt16BigEndian(buffer.AsSpan().Slice(0));
                
        }
    }
}
