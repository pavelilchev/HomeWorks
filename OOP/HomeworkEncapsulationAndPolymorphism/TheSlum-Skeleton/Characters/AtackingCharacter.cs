
using System;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
	public abstract  class AtackingCharacter : Character, IAttack
	{
		private int attackPoints;
		
		public AtackingCharacter(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int atackPoints)
			:base(id, x, y, healthPoints, defensePoints, team, range)
		{
			this.AttackPoints = atackPoints;
		}
		
		public int AttackPoints 
		{
			get
			{
				return this.attackPoints;
			}
			set 
			{
				this.attackPoints = value;;
			}
		}
		
		public override void RemoveFromInventory(Item item)
		{           
            this.RemoveItemEffects(item);
            this.Inventory.Remove(item);            
		}
		
		public override void AddToInventory(Item item)
		{
			this.Inventory.Add(item);
            this.ApplyItemEffects(item);
		}
		
		public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
		{
			Character target = targetsList.FirstOrDefault(t =>  t.Team != this.Team && t.IsAlive);		
			return target;	
		}

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;    
        }

        public override string ToString()
        {
            return string.Format(
             "-- Name: {0}, Team: {2}, Health: {1}, Defense: {3}, Attack: {4}",
             this.Id,
             this.HealthPoints,
             this.Team,
             this.DefensePoints,
             this.AttackPoints);

        }
    }
}
