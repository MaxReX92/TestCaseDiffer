using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDiffer;

namespace TestCaseDiffer.HtmlTags
{
    public abstract class SingleTag : AbstractTag
    {
        public override string Build()
        {
            return  $"<{Name}{Attributes.Select(x => x.Build()).ToSpaceSeparated()}>";
        }
    }
}
