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

        public ElementBuilder(string elementName)
        {
            this.ElementName = elementName;
        }

        public string ElementName { get; set; }

        public void AddAtribute(string attribute, string value)
        {

        }
    }
}
