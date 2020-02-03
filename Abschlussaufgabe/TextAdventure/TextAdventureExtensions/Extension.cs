using System;

namespace TextAdventureCharacter
{
    public static class Extension
    {
        //Extension Code Idear from:
        //https://stackoverflow.com/questions/4335878/c-sharp-trimstart-with-string-parameter
        public static string TrimStr(this string str, string trimStr, 
                    bool trimEnd = true, bool repeatTrim = true,
                    StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            int strLen;
            do
            {
                if (!(str ?? "").EndsWith(trimStr)) return str;
                strLen = str.Length;
                {
                if (trimEnd)
                    {
                    var pos = str.LastIndexOf(trimStr, comparisonType);
                    if ((!(pos >= 0)) || (!(str.Length - trimStr.Length == pos))) break;
                    str = str.Substring(0, pos);
                    }
                    else
                    {
                    var pos = str.IndexOf(trimStr, comparisonType);
                    if (!(pos == 0)) break;
                    str = str.Substring(trimStr.Length, str.Length - trimStr.Length);
                    }
                }
            } while (repeatTrim && strLen > str.Length);
            return str;
        }
        public static string TrimStart(this string str, string trimStr, 
                bool repeatTrim = true,
                StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) 
        {
            return TrimStr(str, trimStr, false, repeatTrim, comparisonType);
        }
    }
}