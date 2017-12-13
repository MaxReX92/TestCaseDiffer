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
			var value = values.SeparatedBy(" ");
			return String.IsNullOrEmpty(value) ? value : $" {value}";
		}

        public static string ToLineSeparated(this IEnumerable<string> values)
        {
			return values.SeparatedBy("\n");
		}

		public static string SeparatedBy(this IEnumerable<string> values, string separator)
		{
			if (values == null || !values.Any())
				return String.Empty;

			return String.Join(separator, values);
		}
    }
}
