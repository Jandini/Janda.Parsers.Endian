using System;
using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class ByteArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ParseAsBEInt16(this byte[] buffer, int index)
        {
            return (short)((buffer[index++] << 8) | buffer[index++]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ParseAsBEUInt16(this byte[] buffer, int index)
        {
            return (ushort)((buffer[index++] << 8) | buffer[index++]);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ParseAsBEUInt16(this byte[] buffer, int index, bool isLittleEndian = false)
        {
            return isLittleEndian != BitConverter.IsLittleEndian
                ? (ushort)((buffer[index++] << 8) | buffer[index++])
                : BitConverter.ToUInt16(buffer, index);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ParseAsBEUInt32(this byte[] buffer, int index)
        {
            return (uint)((buffer[index++] << 24)
                | (buffer[index++] << 16)
                | (buffer[index++] << 8)
                | buffer[index++]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ParseAsBEUInt32(this byte[] buffer, int index, bool isLittleEndian = false)
        {
            return isLittleEndian != BitConverter.IsLittleEndian
                ? (uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++])
                : BitConverter.ToUInt32(buffer, index);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ParseAsBEInt32(this byte[] buffer, int index)
        {
            return (int)((buffer[index++] << 24)
                | (buffer[index++] << 16)
                | (buffer[index++] << 8)
                | buffer[index++]);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ParseAsBEInt64(this byte[] buffer, int index)
        {
            // Using BitConverter and SwapBytes is faster than direct access to buffer
            return BitConverter.ToInt64(buffer, index).SwapBytes();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ParseAsBEUInt64(this byte[] buffer, int index)
        {
            // Using BitConverter and SwapBytes is faster than direct access to buffer
            return BitConverter.ToUInt64(buffer, index).SwapBytes();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteAsBigEndian(this byte[] buffer, int index, uint value)
        {
            buffer[index++] = (byte)((0xFF000000 & value) >> 24);
            buffer[index++] = (byte)((0x00FF0000 & value) >> 16);
            buffer[index++] = (byte)((0x0000FF00 & value) >> 8);
            buffer[index++] = (byte)(0x000000FF & value);
        }
    }
}
 