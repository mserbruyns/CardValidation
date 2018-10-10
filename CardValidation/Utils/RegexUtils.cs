using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardValidation.Utils
{
    public static class RegexUtils
    {
        private static readonly Regex rxNonDigits = new Regex(@"[^\d]+");

        public static string OnlyDigits(string value)
        {
            value = rxNonDigits.Replace(value, "");
            return value;
        }
    }
}
