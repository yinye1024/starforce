/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/



    public static class NetworkUtils
    {

        // 从主机字节序到网络字节序（大端）
        public static byte[] HostToNetworkOrder_UInt16(UInt16 number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes); // 如果系统是小端字节序，则反转数组来获得大端字节序
            }
            return bytes;
        }
        
        // 网络字节序（大端）到 从主机字节序
        public static UInt16 NetworkToHostOrder_UInt16(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes); // 如果系统是小端字节序，则反转数组来获得大端字节序
            }
            UInt16 number = BitConverter.ToUInt16(bytes, 0);
            return number;
        }
        // 从主机字节序到网络字节序（大端）
        public static byte[] HostToNetworkOrder_Int32(Int32 number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes); // 如果系统是小端字节序，则反转数组来获得大端字节序
            }
            return bytes;
        }
        
        // 网络字节序（大端）到 从主机字节序
        public static Int32 NetworkToHostOrder_Int32(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes); // 如果系统是小端字节序，则反转数组来获得大端字节序
            }
            Int32 number = BitConverter.ToInt32(bytes, 0);
            return number;
        }

    }