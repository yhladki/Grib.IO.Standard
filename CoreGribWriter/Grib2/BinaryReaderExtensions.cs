using System;
using System.IO;

namespace Grib.Reader.Standard.Grib2
{
    internal static class BinaryReaderExtensions
    {

        /// <summary>
        /// Read long (8 octets)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>value</returns>
        internal static long ReadGribLong(this BinaryReader reader)
        {
            var readBytes = reader.ReadBytes(8);
            Array.Reverse(readBytes);
            return BitConverter.ToInt64(readBytes, 0);
        }

        /// <summary>
        /// Read int (4 octets)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>value</returns>
        internal static int ReadGribInt(this BinaryReader reader)
        {
            var readBytes = reader.ReadBytes(4);
            Array.Reverse(readBytes);
            return BitConverter.ToInt32(readBytes, 0);
        }

        /// <summary>
        /// Read short (2 octets)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>value</returns>
        internal static short ReadGribShort(this BinaryReader reader)
        {
            var readBytes = reader.ReadBytes(2);
            Array.Reverse(readBytes);
            return BitConverter.ToInt16(readBytes, 0);
        }
    }
}