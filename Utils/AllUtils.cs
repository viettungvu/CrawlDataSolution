using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
{
    public static class AllUtils
    {
        /*
         * Lấy ra chuỗi match với parttern từ string input
         * Param group option: nếu có thì chỉ lấy string trong group đó thôi
         */
        public static string GetRegexString(string input, string pattern, string group = null)
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.Multiline;
            Match m = Regex.Match(input, pattern, options);
            if (!string.IsNullOrEmpty(group))
            {
                return m.Groups[group].Value;
            }
            return m.Value;
        }
        /*
         * Trả về 1 matchcollection từ ...
         */
        public static MatchCollection GetCollectionRegex(string input, string parttern)
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.Multiline;
            return Regex.Matches(input, parttern, options);
        }
        /*
         * Lấy ra đoạn gộp chuỗi của 1 group trong tất cả match của côle4ction
         * Mỗi match trên 1 dòng
         */
        public static string GetStringCollection(string input, string parttern, string group)
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.Multiline;
            MatchCollection collection = Regex.Matches(input, parttern, options);
            string value = "";
            foreach (Match m in collection)
            {
                value += m.Groups[group].Value + "; ";
            }
            return value;
        }

        static readonly DateTime epoch = new(1970, 1, 1);
        public static long TimeInEpoch(DateTime? dt = null)
        {
            if (dt.HasValue)
                return (long)(dt.Value.ToUniversalTime() - epoch).TotalSeconds;
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        public static DateTimeOffset EpochToTime(long ep)
        {
            return DateTimeOffset.FromUnixTimeSeconds(ep).ToLocalTime();
        }
        public static string EpochToTimeStringShortFormat(long ep)
        {
            return EpochToTime(ep).ToString("dd/MM/yyyy HH:mm");
        }
        public static string EpochToTimeString(long ep, string format = "dd/MM/yyyy HH:mm:ss")
        {
            return EpochToTime(ep).ToString(format);
        }
    }
    public static class EntendsionMethod
    {

        public static string ToTimeString(this DateTime time, string format = "MM/dd/yyyy")
        {
            return time.ToString(format);
        }
        static readonly List<string> specialChar = new() { "-", "\"", "+", "=", "&&", "||", ">", "<", "!", "(", ")", "{", "}", "[", "]", "^", "~", ":", "\\", "/", ",", "?", "@", "#", "$", "%", "*", "." };
        static readonly List<string> digitSepatator = new List<string>() { ".", "," };
        public static string RemoveSpecialChar(this string str)
        {
            specialChar.ForEach(x =>
            {
                if (str.Contains(x))
                {
                    str = str.Replace(x, " ");
                }
            });
            return str;
        }
        public static decimal ConvertToDecimal(this string stringVal)
        {
            decimal decimalVal;
            try
            {
                decimalVal = Convert.ToDecimal(stringVal);
            }
            catch (System.OverflowException)
            {
                throw new Exception(
                     "The conversion from string to decimal overflowed.");
            }
            catch (System.ArgumentNullException)
            {
                throw new Exception(
                    "The string is null.");
            }
            catch (System.FormatException)
            {
                throw new Exception(
                    "The string is not formatted as a decimal.");
            }
            return decimalVal;
        }
        private static long ToLong(this string stringValue)
        {
            long value = 0;
            try
            {
                value = Convert.ToInt64(stringValue);
            }
            catch (System.OverflowException)
            {
                throw new Exception(
                     "The conversion from string to decimal overflowed.");
            }
            catch (System.ArgumentNullException)
            {
                throw new Exception(
                    "The string is null.");
            }
            catch (System.FormatException)
            {
                throw new Exception(
                    "The string is not formatted as a long");
            }
            return value;
        }
        public static long ConvertToLong(this string stringVal)
        {
            long longVal = 0;
            if (Regex.IsMatch(stringVal, Constant.DECIMAL_GSEPARATOR_PARTTERN))
            {
                digitSepatator.ForEach(x =>
                {
                    stringVal = stringVal.Replace(x, "");
                });
                longVal = stringVal.ToLong();
            }
            else if (Regex.IsMatch(stringVal, Constant.DECIMAL_PARTTERN))
            {
                longVal = Convert.ToInt64(stringVal.ConvertToDecimal());
            }
            else if (Regex.IsMatch(stringVal, Constant.DIGIT_PARTTERN))
            {
                longVal = stringVal.ToLong();
            }
            else
            {
                throw new Exception(
                   "The string is not formatted as a long");
            }
            return longVal;
        }
    }
}

