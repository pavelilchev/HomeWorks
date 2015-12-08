
using System;

namespace Problem3GenericList
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum |  AttributeTargets.Struct 
	                | AttributeTargets.Interface | AttributeTargets.Method)]
	public class VersionAttribute : Attribute
	{
		public VersionAttribute(string version)
		{
			this.Version = version;
		}
		
		public string Version { get; set; }
	}
}
