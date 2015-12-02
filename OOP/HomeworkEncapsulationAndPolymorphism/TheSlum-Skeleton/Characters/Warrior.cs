
using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
	public class Warrior : AtackingCharacter
	{
		private const int DefaultWarriorHealth = 200;
		private const int DefaultWarirorDefense = 100;
		private const int DefaultWarriorAttack = 150;
		private const int DefaultWarriorRange = 2;		
		
		public Warrior(string id, int x, int y, Team team)
			:base(id, x, y, Warrior.DefaultWarriorHealth, Warrior.DefaultWarirorDefense, team, Warrior.DefaultWarriorRange, Warrior.DefaultWarriorAttack)
		{
			
		}		
	}
}
