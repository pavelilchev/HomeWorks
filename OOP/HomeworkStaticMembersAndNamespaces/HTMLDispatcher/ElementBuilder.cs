using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
   public class ElementBuilder
    {
        private string elementName;
        private string element;

        public ElementBuilder(string elementName)
        {
            this.ElementName = elementName;
            CreateElement(this.ElementName);
            this.Index = CalculateIndex();
        }

        public string ElementName { get; set; }

        public string Element { get; set; }

        public int Index { get; set; }

        private void CreateElement(string name)
        {
            string result = string.Format(@"<{0}></{0}>", name);
            this.Element = result;
        }

        private int CalculateIndex()
        {
            int index = this.Element.IndexOf(this.ElementName) + this.ElementName.Length;

            return index;
        }

        public void AddAttribute(string attribute, string value)
        {
            string insert = string.Format(@" {0}=""{1}""", attribute, value);
            this.Element = this.Element.Insert(this.Index, insert);
            this.Index += insert.Length;
        }

        public void AddContent(string text)
        {
            int indexOfTag = this.Element.IndexOf(">") + 1;
            this.Element = this.Element.Insert(indexOfTag, text);
        }

        public static string operator *(ElementBuilder el, int number)
        {
            StringBuilder sb = new StringBuilder();           

            for (int i = 0; i < number; i++)
            {
                sb.Append(el.Element);
            }           

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Element;
        }
    }
}
