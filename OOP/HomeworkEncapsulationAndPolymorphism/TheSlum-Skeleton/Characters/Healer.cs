
using System;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        private const int DefaultHealerHealth = 75;
        private const int DefaultHealerDefense = 50;
        private const int DefaultHealerHealingPoints = 60;
        private const int DefaultHealerRange = 6;
        private int healingPoints;

        public Healer(string id, int x, int y, Team team) :
            base(id, x, y, DefaultHealerHealth, DefaultHealerDefense, team, DefaultHealerRange)
        {
            this.HealingPoints = Healer.DefaultHealerHealingPoints;
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }
            set
            {
                this.healingPoints = value;
            }
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            var optimaltarget = targetsList
                .Where(t => t.Team == this.Team && t.IsAlive && t.Id != this.Id)
                .OrderBy(x => x.HealthPoints)
                .FirstOrDefault();

            return optimaltarget;
        }

        public override string ToString()
        {           
            return string.Format(
             "-- Name: {0}, Team: {2}, Health: {1}, Defense: {3}, Healing: {4}",
             this.Id,
             this.HealthPoints,
             this.Team,
             this.DefensePoints,
             this.HealingPoints);

        }
    }
}
