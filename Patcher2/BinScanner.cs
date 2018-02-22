using System;
using System.Globalization;

namespace Patcher2
{
    public static class BinScanner
    {
        public static int FindPattern(byte[] buffer, string pattern)
        {
            var mask = string.Empty;
            var patternBlocks = pattern.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var binPattern = new byte[patternBlocks.Length];

            for (var i = 0; i < patternBlocks.Length; i++)
            {
                var block = patternBlocks[i];
                if (block == "?")
                {
                    mask += '?';
                    binPattern[i] = 0;
                }
                else
                {
                    mask += 'x';
                    binPattern[i] = byte.Parse(patternBlocks[i], NumberStyles.HexNumber);
                }
            }

            return FindPattern(buffer, binPattern, mask);
        }

        public static int FindPattern(byte[] buffer, byte[] pattern, string mask)
        {
            // check every byte - source
            for (var s = 0; s < buffer.Length; s++)
            {
                // check every byte - pattern
                for (var f = 0; f < pattern.Length; f++)
                {
                    // pattern and source doesn't match
                    if (mask[f] == 'x' && buffer[s + f] != pattern[f])
                    {
                        break;
                    }

                    // bytes found
                    if (f + 1 == pattern.Length)
                    {
                        // success
                        return s;
                    }
                }
            }

            // fail
            return 0;
        }
    }
}
