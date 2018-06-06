using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RangeImageWriter
{
    class LCMSWrapper
    {
        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LcmsGetLibVersion(byte[] lib);


        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 LcmsOpenRoadSection(char[] path);


        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 LcmsGetIntData([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))]byte[][] _pIntData);

        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 LcmsGetRectifiedRngIm([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))]byte[][] _pRectifiedRngData);

        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 LcmsGetRngProfiles(int[] _auiIndexJ, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))]float[][] _pRngProfX, 
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))]float[][] _pRngProfZ);

        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 LcmsGetRngData([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))]float[][] _pRngDataX,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JaggedArrayMarshaler))]float[][] _pRngDataZ, ref float _pfInvalidDataVal);


        [DllImport("LcmsAnalyserLibAdv.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LcmsCloseRoadSection();


    }
}
