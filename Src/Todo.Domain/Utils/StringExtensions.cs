using System;
using System.Linq;

namespace Todo.Domain.Utils
{
    public static class StringExtensions
    {
        public static string Capitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return new String(value.Select((c, index) => {
                return index == 0
                    ? Char.ToUpper(c)
                    : Char.ToLower(c);
            }).ToArray());
        }
    }
}
