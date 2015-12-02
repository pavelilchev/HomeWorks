
using System;

namespace TheSlum.Items
{	
	public class Shield : Item
	{
		private const int ShieldHealthEffect = 0;
		private const int ShieldDefenseEffect = 50;
		private const int ShieldAttackEffect = 0;
		
		public Shield(string id) : base(id, ShieldHealthEffect, ShieldDefenseEffect, ShieldAttackEffect)
		{			
		}
	}
}
