
using System;

namespace TheSlum.Items
{
	public class Injection : Bonus
	{
		private const int InjectionHealthEffect = 200;
        private const int InjectionDefenseEffect = 0;
        private const int InjectionAttackEffect = 0;
        private const int InjectionCount = 3;
            
            public Injection(string id) : base(id, InjectionHealthEffect, InjectionDefenseEffect, InjectionAttackEffect)
		{
            this.Timeout = InjectionCount;
            this.Countdown = InjectionCount;
        }
	}
}
