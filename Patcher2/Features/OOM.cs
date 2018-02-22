namespace Patcher2.Features
{
    public static class OOM
    {
        // #1
        // [8bytes] movss [esi+00000130],xmm2 <--- NOP
        // [1byte] ja ..

        // #2
        // [8bytes] movss [esi+00000138],xmm0 <--- NOP
        // [2bytes] jbe ...

        public static bool Process(ref byte[] buffer)
        {
            var index1 = BinScanner.FindPattern(buffer, "F3 0F 11 96 30 01 00 00 77");
            if (index1 == 0)
            {
                return false;
            }

            var index2 = BinScanner.FindPattern(buffer, "F3 0F 11 86 38 01 00 00 0F 86");
            if (index2 == 0)
            {
                return false;
            }

            buffer[index1 + 0] = 0x90;
            buffer[index1 + 1] = 0x90;
            buffer[index1 + 2] = 0x90;
            buffer[index1 + 3] = 0x90;
            buffer[index1 + 4] = 0x90;
            buffer[index1 + 5] = 0x90;
            buffer[index1 + 6] = 0x90;
            buffer[index1 + 7] = 0x90;

            buffer[index2 + 0] = 0x90;
            buffer[index2 + 1] = 0x90;
            buffer[index2 + 2] = 0x90;
            buffer[index2 + 3] = 0x90;
            buffer[index2 + 4] = 0x90;
            buffer[index2 + 5] = 0x90;
            buffer[index2 + 6] = 0x90;
            buffer[index2 + 7] = 0x90;

            return true;
        }
    }
}
