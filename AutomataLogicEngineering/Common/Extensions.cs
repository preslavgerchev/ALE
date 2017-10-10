namespace AutomataLogicEngineering.Common
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A static class, providing extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts the given string of binary input to hexadecimal string.
        /// </summary>
        /// <param name="binary">The binary input.</param>
        /// <returns>The binary, converted to hexadecimal.</returns>
        public static string ToHexString(this string binary)
        {
            if (binary.Any(x => x != '0' && x != '1'))
            {
                throw new Exception("Found invalid chars in binary input");
            }

            var result = new StringBuilder(binary.Length / 8 + 1);
            var mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // Pad to length multiple of 8.
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (var i = 0; i < binary.Length; i += 8)
            {
                var eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
    }
}
