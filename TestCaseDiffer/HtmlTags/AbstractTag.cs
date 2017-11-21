using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.HtmlTags
{
    public abstract class AbstractTag
    {
        public ICollection<TagAttribute> Attributes { get; } = new List<TagAttribute>();

        public void AddAttribute(TagAttribute attribute)
        {
            Attributes.Add(attribute);
        }

        public void AddAttributesRange(IEnumerable<TagAttribute> attributes)
        {
            foreach (var attr in attributes)
                AddAttribute(attr);
        }

        protected abstract string Name { get; }

        public abstract string Build();
    }
}
