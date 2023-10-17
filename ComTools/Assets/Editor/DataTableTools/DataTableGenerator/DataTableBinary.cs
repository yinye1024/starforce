
using System.IO;


namespace ComTools
{
    public static class DataTableBinary
    {
        public static void Write7BitEncodedUInt32(BinaryWriter binaryWriter, uint value)
        {
            Write7BitEncodedInt32(binaryWriter, (int)value);
        }
        /// <summary>
        /// 向二进制流写入编码后的 32 位有符号整数。
        /// </summary>
        /// <param name="binaryWriter">要写入的二进制流。</param>
        /// <param name="value">要写入的 32 位有符号整数。</param>
        public static void Write7BitEncodedInt32(BinaryWriter binaryWriter, int value)
        {
            uint num = (uint)value;
            while (num >= 0x80)
            {
                binaryWriter.Write((byte)(num | 0x80));
                num >>= 7;
            }

            binaryWriter.Write((byte)num);
        }
        
        /// <summary>
        /// 向二进制流写入编码后的 64 位无符号整数。
        /// </summary>
        /// <param name="binaryWriter">要写入的二进制流。</param>
        /// <param name="value">要写入的 64 位无符号整数。</param>
        public static void Write7BitEncodedUInt64(BinaryWriter binaryWriter, ulong value)
        {
            Write7BitEncodedInt64(binaryWriter, (long)value);
        }

        /// <summary>
        /// 向二进制流写入编码后的 64 位无符号整数。
        /// </summary>
        /// <param name="binaryWriter">要写入的二进制流。</param>
        /// <param name="value">要写入的 64 位无符号整数。</param>
        public static void Write7BitEncodedInt64(this BinaryWriter binaryWriter, long value)
        {
            ulong num = (ulong)value;
            while (num >= 0x80)
            {
                binaryWriter.Write((byte)(num | 0x80));
                num >>= 7;
            }

            binaryWriter.Write((byte)num);
        }
        
    }
}
