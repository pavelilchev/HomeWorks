
using System;

namespace TheSlum.Characters
{
	public class Mage : AtackingCharacter
	{		
		private const int DefaultMageHealth = 150;
		private const int DefaultMageDefense = 50;
		private const int DefaultMageAttack = 300;
		private const int DefaultMageRange = 5;		
		
		public Mage(string id, int x, int y, Team team)
			:base(id, x, y, Mage.DefaultMageHealth, Mage.DefaultMageDefense, team, Mage.DefaultMageRange, Mage.DefaultMageAttack)
		{
			
		}		
	}
}
