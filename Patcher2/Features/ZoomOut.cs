namespace Patcher2.Features
{
    public static class ZoomOut
    {
        // [6bytes] eax,[esi+0000022C]
        // [5bytes] xmm0,[eax+28]
        // [2bytes] jmp
        // [8bytes] movss xmm0,[?]
        // [3bytes] comiss xmm1,xmm0 <--- NOP

        public static bool Process(ref byte[] buffer)
        {
            var index = BinScanner.FindPattern(buffer, "8B 86 2C 02 00 00 F3 0F 10 40 28 EB 08 F3 0F 10 05 ? ? ? ? 0F 2F C8");
            if (index == 0)
            {
                return false;
            }

            buffer[index + 21] = 0x90;
            buffer[index + 22] = 0x90;
            buffer[index + 23] = 0x90;

            return true;
        }
    }
}
