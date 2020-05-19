using System.IO;
using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class BinaryReaderExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ParseBEUInt32(this BinaryReader reader)
        {
            uint value = reader.ReadUInt32();

            return (uint)((0x000000FF) & (value >> 24)
               | (0x0000FF00) & (value >> 8)
               | (0x00FF0000) & (value << 8)
               | (0xFF000000) & (value << 24));
        }
    }
}
