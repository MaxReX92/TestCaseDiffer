using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer;

namespace TestCaseDiffer.HtmlTags
{
    public class SingleTag : AbstractTag
    {
        public SingleTag(string name)
        {
            Name = name;
        }

        protected override string Name { get; }

        public override string Build()
        {
            return  $"<{Name}{Attributes.Select(x => x.Build()).ToSpaceSeparated()}>";
        }
    }
}
