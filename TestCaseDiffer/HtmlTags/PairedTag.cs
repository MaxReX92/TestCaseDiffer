using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.HtmlTags
{
    public class PairedTag : AbstractTag
    {
		private List<AbstractTag> _subTags;

		public PairedTag(string name)
		{
			_subTags = new List<AbstractTag>();
			Name = name;
		}

		public IReadOnlyCollection<AbstractTag> SubTags => _subTags;
        protected override string Name { get; }

        public void AddSubTag(AbstractTag tag)
        {
			_subTags.Add(tag);
        }

		public void InsertSubTag(int index, AbstractTag tag)
		{
			_subTags.Insert(index, tag);
		}

        public void AddSubTagRange(IEnumerable<AbstractTag> tags)
        {
            foreach (var tag in tags)
                AddSubTag(tag);
        }
        

        public override string Build()
        {
            return $"<{Name}{Attributes.Select(x => x.Build()).ToSpaceSeparated()}>{SubTags.Select(x => x.Build()).SeparatedBy(String.Empty)}</{Name}>";
        }
    }
}
