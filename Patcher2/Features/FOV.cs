using System;
using Patcher2.Forms;

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

            var textFrm = new TextForm();
            textFrm.titleLbl.Text = $"FOV Value:{Environment.NewLine}(45 - default)";
            textFrm.ShowDialog();

            if (!textFrm.Success)
            {
                return false;
            }

            var valueStr = textFrm.valueLbl.Text.Trim();

            if(!float.TryParse(valueStr, out var value))
            {
                return false;
            }

            var valueBin = BitConverter.GetBytes(value);

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
