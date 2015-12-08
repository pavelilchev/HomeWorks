
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Problem3GenericList
{
	class MainGenericList
	{
		public static void Main(string[] args)
		{
			GenericList<int> myList = new GenericList<int>();
			Console.WriteLine(myList);
			myList.Add(5);
			myList.Add(1);
			myList.Add(8);
			myList.Add(7);
			myList.Add(5);
			myList.Add(9);
			
			Console.WriteLine(myList);
			Console.WriteLine(myList.Contains(0));
			Console.WriteLine(myList.Contains(5));
			
			myList.Remove(4);
			Console.WriteLine(myList);
			
			Console.WriteLine(myList.Find(7));
			Console.WriteLine(myList.Count);
			
			Console.WriteLine(myList.Min());
			Console.WriteLine(myList.Max());
			
			myList.Insert(21, 1);
			Console.WriteLine(myList);
			
			Console.WriteLine(myList[1]);
			myList[1] = 19;
			Console.WriteLine(myList);
			
			Type type = typeof(GenericList<int>);
			
        	foreach (Attribute attr in type.GetCustomAttributes(true))
        	{
            	VersionAttribute version = attr as VersionAttribute;
           		 if (null != attr as VersionAttribute)
            	 {
               		 Console.WriteLine("Version: {0}", version.Version);
          		 }
      	   }
			
		  Console.ReadKey(true);	
        }
	}
}