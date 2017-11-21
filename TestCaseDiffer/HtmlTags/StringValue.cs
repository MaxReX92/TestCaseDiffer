using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.HtmlTags
{
    public class StringValue : AbstractTag
    {
        public StringValue(string value)
        {
            Name = value;
        }

        protected override string Name { get; }

        public override string Build()
        {
            return Name;
        }
    }
}
