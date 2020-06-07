using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class ByteArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReadAsBigEndianToInt16(this byte[] buffer, int index)
        {
            return (short)((buffer[index++] << 8) | buffer[index++]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReadAsBigEndianToUInt16(this byte[] buffer, int index)
        {
            return (ushort)((buffer[index++] << 8) | buffer[index++]);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReadAsBigEndianToUnit16(this byte[] buffer, int index, bool isLittleEndian = false)
        {
            return isLittleEndian != BitConverter.IsLittleEndian
                ? (ushort)((buffer[index++] << 8) | buffer[index++])
                : BitConverter.ToUInt16(buffer, index);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReadAsBigEndianToUInt32(this byte[] buffer, int index)
        {
            return (uint)((buffer[index++] << 24)
                | (buffer[index++] << 16)
                | (buffer[index++] << 8)
                | buffer[index++]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReadAsBigEndianToUInt32(this byte[] buffer, int index, bool isLittleEndian = false)
        {
            return isLittleEndian != BitConverter.IsLittleEndian
                ? (uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++])
                : BitConverter.ToUInt32(buffer, index);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadAsBigEndianToInt32(this byte[] buffer, int index)
        {
            // This is slightliy faster than BinaryPrimitives.ReadInt32BigEndian
            // 339ms vs 592ms
            return (int)((buffer[index++] << 24)
                | (buffer[index++] << 16)
                | (buffer[index++] << 8)
                | buffer[index++]);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ReadAsBigEndianToInt64(this byte[] buffer, int index)
        {
            // BinaryPrimitives are 4x faster than BitConverter 
            Span<byte> span = buffer;
            return BinaryPrimitives.ReadInt64BigEndian(span.Slice(index));            
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ReadAsBigEndianToUInt64(this byte[] buffer, int index)
        {
            Span<byte> span = buffer;
            return BinaryPrimitives.ReadUInt64BigEndian(span.Slice(index));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteAsBigEndianUInt32(this byte[] buffer, int index, uint value)
        {
            Span<byte> span = buffer;
            BinaryPrimitives.WriteUInt32BigEndian(span.Slice(index), value);
        }
    }
}
 