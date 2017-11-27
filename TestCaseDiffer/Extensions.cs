using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer
{
    public static class Extensions
    {
        public static string ToSpaceSeparated(this IEnumerable<string> values)
        {
            if (values == null || !values.Any())
                return String.Empty;

            return $" {String.Join(" ", values)}";
        }

        public static string ToLineSeparated(this IEnumerable<string> values)
        {
            if (values == null || !values.Any())
                return String.Empty;

            return String.Join("\n\r\t", values);
        }
    }
}
