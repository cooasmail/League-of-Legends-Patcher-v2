namespace Patcher2.Features
{
    public static class ZoomIn
    {
        // #1
        // [2bytes] ja
        // [5bytes] movss xmm0,[eax+24]
        // [4bytes] maxss xmm0,xmm1 <--- MOVSS

        // #2
        // [6bytes] mov eax,[esi+0000022C]
        // [5bytes] movss xmm0,[eax+24]
        // [4bytes] maxss xmm0,xmm1 <--- MOVSS

        public static bool Process(ref byte[] buffer)
        {
            var index1 = BinScanner.FindPattern(buffer, "77 09 F3 0F 10 40 24 F3 0F 5F C1");
            if (index1 == 0)
            {
                return false;
            }

            var index2 = BinScanner.FindPattern(buffer, "8B 86 2C 02 00 00 F3 0F 10 40 24 F3 0F 5F C1");
            if (index2 == 0)
            {
                return false;
            }

            buffer[index1 + 9] = 0x10;
            buffer[index2 + 13] = 0x10;

            return true;
        }
    }
}
