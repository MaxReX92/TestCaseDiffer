using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer.HtmlTags
{
    public class TagAttribute
    {
        public TagAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }

        public string Build()
        {
            return $"{Key}:{Value}";
        }
    }
}
