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
        public static MatchCollection Find2(string s, string signature)
        {
            Regex regex = new Regex(@"\Wma\w*");
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
        public static MatchCollection FindFile(string s)
        {
            Regex regex = new Regex(@"savedGame_\w*");
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
