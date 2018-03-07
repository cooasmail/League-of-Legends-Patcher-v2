using System;

namespace Patcher2.Features
{
    public static class TopView
    {
        // https://prtsc.me/i/d68ef574.png
        // https://prtsc.me/i/f054717d.png
        // [8bytes] movss xmm0,[edi+148] <--- BA X X X X 66 0F 6E
        // [3bytes] xorps xmm7, xmm7 <--- C2 90 90

        public static bool Process(ref byte[] buffer)
        {
            var index = BinScanner.FindPattern(buffer, "F3 0F 10 87 48 01 00 00 0F 57 FF");
            if (index == 0)
            {
                return false;
            }

            var valueBin = BitConverter.GetBytes(89f);

            buffer[index + 0] = 0xBA;
            buffer[index + 1] = valueBin[0];
            buffer[index + 2] = valueBin[1];
            buffer[index + 3] = valueBin[2];
            buffer[index + 4] = valueBin[3];
            buffer[index + 5] = 0x66;
            buffer[index + 6] = 0x0F;
            buffer[index + 7] = 0x6E;
            buffer[index + 8] = 0xC2;
            buffer[index + 9] = 0x90;
            buffer[index + 10] = 0x90;

            return true;
        }
    }
}
