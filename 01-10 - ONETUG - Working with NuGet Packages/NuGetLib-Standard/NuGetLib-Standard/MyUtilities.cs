using System;
using System.Text;

namespace NuGetLib_Standard
{
    public class MyUtilities
    {
        public string LeftPad(string text, int requiredLength)
        {
            if (text.Length >= requiredLength)
            {
                return text;
            }

            var builder = new StringBuilder(requiredLength);
            var spacesToAdd = text.Length - requiredLength;
            builder.Append(' ', spacesToAdd);
            builder.Append(text);

            return builder.ToString();
        }
    }
}
