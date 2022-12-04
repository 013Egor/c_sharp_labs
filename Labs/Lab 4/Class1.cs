using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Labs.Lab_4
{
    public class Class1
    {
        public static MatchCollection Find(string s, string signature)
        {
            Regex regex = new Regex(signature, RegexOptions.IgnoreCase);
            if (s != null)
            {
                MatchCollection matches = regex.Matches(s);
                return matches;
            }
            else
            {
                return null;
            }
        }
        public static MatchCollection Date(string s)
        {
            Regex regex = new Regex(@"(0?[1-9]|[12][0-9]|3[01])[.](0?[1-9]|1[012])[.]\d{4}");
            if (s != null)
            {
                MatchCollection matches = regex.Matches(s);
                return matches;
            }
            else
            {
                return null;
            }
        }
    }
}
