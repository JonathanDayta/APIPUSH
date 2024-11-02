using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class StringExtension
    {
        public static int IndexOfEx(this string str,string value,int startIndex=0, StringComparison stringComparison=StringComparison.OrdinalIgnoreCase)
        {
            return str.IndexOf(value, startIndex, stringComparison);
        }

        public static bool isEmpty(string cs)
        {
            return cs == null || cs.Length == 0;
        }

        public static bool isNotEmpty(string cs)
        {
            return !isEmpty(cs);
        }

        public static bool isNotNullEmptyBlank(string cs)
        {
            return !isEmpty(cs) && !isBlank(cs);
        }

        public static bool isBlank(string cs)
        {
            int strLen = cs.Length;
            if (strLen == 0)
            {
                return true;
            }
            for (int i = 0; i < strLen; i++)
            {
                if (!char.IsWhiteSpace(cs[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isNotBlank(string cs)
        {
            return !isBlank(cs);
        }
    }
}
