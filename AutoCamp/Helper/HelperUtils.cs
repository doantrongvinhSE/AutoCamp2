using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoCamp.Helper
{
     public class HelperUtils
    {
        public static string ExtractUserIdFromCookie(string cookie)
        {
            string pattern = @"c_user=(\d+);";
            Match match = Regex.Match(cookie, pattern);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }
    }
}
