using System;

namespace Patcher2.Features
{
    public static class FOV
    {
        // [2bytes] mov ecx,esi
        // [7bytes] mov [esi+48],0
        // [6bytes] mov eax,[edi+15C] <--- B8 X X X X 90

        public static bool Process(ref byte[] buffer)
        {
            var index = BinScanner.FindPattern(buffer, "8B CE C7 46 48 00 00 00 00 8B 87 5C 01 00 00");
            if (index == 0)
            {
                return false;
            }

            var valueBin = BitConverter.GetBytes(52f);

            buffer[index + 9] = 0xB8;
            buffer[index + 10] = valueBin[0];
            buffer[index + 11] = valueBin[1];
            buffer[index + 12] = valueBin[2];
            buffer[index + 13] = valueBin[3];
            buffer[index + 14] = 0x90;

            return true;
        }
    }
}
