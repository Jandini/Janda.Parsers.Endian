using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class EndianExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short SwapBytes(this short value)
        {
            return (short)((0x00FF) & ((ushort)value >> 8) | (0xFF00) & ((ushort)value << 8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort SwapBytes(this ushort value)
        {
            return (ushort)((0x00FF) & (value >> 8) | (0xFF00) & (value << 8));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SwapBytes(this int value)
        {
            return (int)((0x000000FF) & ((uint)value >> 24)
                 | (0x0000FF00) & ((uint)value >> 8)
                 | (0x00FF0000) & ((uint)value << 8)
                 | (0xFF000000) & ((uint)value << 24));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SwapBytes(this uint value)
        {
            return (uint)((0x000000FF) & (value >> 24)
                 | (0x0000FF00) & (value >> 8)
                 | (0x00FF0000) & (value << 8)
                 | (0xFF000000) & (value << 24));
        }   

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SwapBytes(this long value)
        {
            return (long)((0x00000000000000FF) & ((ulong)value >> 56)
                | (0x000000000000FF00) & ((ulong)value >> 40)
                | (0x0000000000FF0000) & ((ulong)value >> 24)
                | (0x00000000FF000000) & ((ulong)value >> 8)
                | (0x000000FF00000000) & ((ulong)value << 8)
                | (0x0000FF0000000000) & ((ulong)value << 24)
                | (0x00FF000000000000) & ((ulong)value << 40)
                | (0xFF00000000000000) & ((ulong)value << 56));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SwapBytes(this ulong value)
        {
            return ((0x00000000000000FF) & (value >> 56)
                 | (0x000000000000FF00) & (value >> 40)
                 | (0x0000000000FF0000) & (value >> 24)
                 | (0x00000000FF000000) & (value >> 8)
                 | (0x000000FF00000000) & (value << 8)
                 | (0x0000FF0000000000) & (value << 24)
                 | (0x00FF000000000000) & (value << 40)
                 | (0xFF00000000000000) & (value << 56));
        }    
    }
}
 