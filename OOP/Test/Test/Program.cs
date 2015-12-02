using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums.Add(1);
            nums.Add(2);
            nums.Add(3);

            if (!nums.Contains(0) &
               !nums.Contains(2))
            {
                throw new InvalidOperationException("The venue {0} does not support the type of performance {1}");
            }
        }
    }
}
