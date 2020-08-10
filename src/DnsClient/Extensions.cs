using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DnsClient
{
    internal static class Extensions
    {
        public static IReadOnlyCollection<T> GetEmptyCollection<T>()
        {
#if NET20
            return new ReadOnlyListEx<T>(new T[0]);
#else
            return new T[0];
#endif
        }

        public static IReadOnlyList<T> GetEmptyList<T>()
        {
#if NET20
            return new ReadOnlyListEx<T>(new T[0]);
#else
            return new T[0];
#endif
        }

        public static bool IsNullOrWhiteSpace(string str)
        {
#if NET20
            return string.IsNullOrEmpty(str?.Trim());
#else
            return StringExtensions.IsNullOrWhiteSpace(str);
#endif
        }
    }

    public static class StringExtensions
    {
        public static string Join(string sep, IEnumerable<string> values)
        {
#if NET20
            return string.Join(sep, values?.ToArray());
#else
            return string.Join(sep, values);
#endif
        }

        public static string Join<T>(string separator, IEnumerable<T> values)
        {
#if NET20
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (separator == null)
            {
                separator = string.Empty;
            }

            using (var enumerator = values.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return string.Empty;
                }

                var stringBuilder = new StringBuilder();
                if (enumerator.Current != null)
                {
                    string text = enumerator.Current.ToString();
                    if (text != null)
                    {
                        stringBuilder.Append(text);
                    }
                }

                while (enumerator.MoveNext())
                {
                    stringBuilder.Append(separator);
                    if (enumerator.Current != null)
                    {
                        string text2 = enumerator.Current.ToString();
                        if (text2 != null)
                        {
                            stringBuilder.Append(text2);
                        }
                    }
                }

                return stringBuilder.ToString();
            }
#else
            return string.Join(separator, values);
#endif
        }

//        public static string Join(string separator, IEnumerable<object> values)
//        {
//#if NET20
//            if (values == null)
//            {
//                throw new ArgumentNullException("values");
//            }

//            if (separator == null)
//            {
//                separator = string.Empty;
//            }

//            using (var enumerator = values.GetEnumerator())
//            {
//                if (!enumerator.MoveNext())
//                {
//                    return string.Empty;
//                }

//                var stringBuilder = new StringBuilder();
//                if (enumerator.Current != null)
//                {
//                    string text = enumerator.Current.ToString();
//                    if (text != null)
//                    {
//                        stringBuilder.Append(text);
//                    }
//                }

//                while (enumerator.MoveNext())
//                {
//                    stringBuilder.Append(separator);
//                    if (enumerator.Current != null)
//                    {
//                        string text2 = enumerator.Current.ToString();
//                        if (text2 != null)
//                        {
//                            stringBuilder.Append(text2);
//                        }
//                    }
//                }

//                return stringBuilder.ToString();
//            }
//#else
//            return string.Join(separator, values);
//#endif
//        }

        public static bool IsNullOrWhiteSpace(string val)
        {
#if NET20
            return string.IsNullOrEmpty(val?.Trim());
#else
            return string.IsNullOrWhiteSpace(val);
#endif
        }

#if !NET20
        public static IReadOnlyList<T> ToReadOnlyList<T>(this T[] arr)
        {
            return new List<T>(arr);
        }
        public static IReadOnlyList<T> ToReadOnlyList<T>(this IReadOnlyCollection<T> arr)
        {
            return new List<T>(arr);
        }
#endif
    }

    public static class TimeoutEx
    {
        public static TimeSpan InfiniteTimeSpan => new TimeSpan(0, 0, 0, 0, -1);
    }   
}
