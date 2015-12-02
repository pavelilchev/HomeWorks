
using System;

namespace TheSlum.Items
{
	public class Axe : Item
	{
		private const int AxeHealthEffect = 0;
		private const int AxeDefenseEffect = 0;
		private const int AxeAttackEffect = 75;
		
		public Axe(string id) : base(id, AxeHealthEffect, AxeDefenseEffect, AxeAttackEffect)
		{
			
		}
	}
}
