using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.HtmlTags
{
    public class PairedTag : AbstractTag
    {
        public PairedTag(string name)
        {
            Name = name;
        }

        public ICollection<AbstractTag> SubTags = new List<AbstractTag>();
        protected override string Name { get; }

        public void AddSubTag(AbstractTag tag)
        {
            SubTags.Add(tag);
        }

        public void AddSubTagRange(IEnumerable<AbstractTag> tags)
        {
            foreach (var tag in tags)
                AddSubTag(tag);
        }

        

        public override string Build()
        {
            return $"<{Name}{Attributes.Select(x => x.Build()).ToSpaceSeparated()}>{SubTags.Select(x => x.Build()).ToLineSeparated()}</{Name}>";
        }
    }
}
