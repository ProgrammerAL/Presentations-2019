using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetLib_Framework
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
