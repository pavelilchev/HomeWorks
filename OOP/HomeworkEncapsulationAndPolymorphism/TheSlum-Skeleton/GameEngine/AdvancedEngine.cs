
using System;
using System.Linq;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
	public class AdvancedEngine : Engine
	{       

        protected override void ExecuteCommand(string[] inputParams)
		{
			base.ExecuteCommand(inputParams);
			
			switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;    
            }
		}			
		
		private void AddItem(string[] inputParams)
		{
			Item item = null;
			switch (inputParams[2])
			{
				case "axe":
					item = new Axe(inputParams[3]);
					break;
				case "shield":
					item = new Shield(inputParams[3]);
					break;
				case "pill":
					item = new Pill(inputParams[3]);
					break;
				case "injection":
					item = new Injection(inputParams[3]);
					break;					
			}

            var target = base.GetCharacterById(inputParams[1]); 
			
			target.AddToInventory(item);	
		}
		
		protected override void CreateCharacter(string[] inputParams)
		{
			string id = inputParams[2];
			int x = int.Parse(inputParams[3]);
			int y = int.Parse(inputParams[4]);
			Team team;
			Enum.TryParse(inputParams[5], out team);
			
			switch (inputParams[1])
            {
                case "warrior":
					Warrior warrior = new Warrior(id, x,y,team);
					this.characterList.Add(warrior);
                    break;
                 case "mage":
                    Mage mage = new Mage(id, x,y,team);
					this.characterList.Add(mage);
                    break;
                case "healer":
                    Healer healer = new Healer(id, x, y, team);
                    this.characterList.Add(healer);
                    break;
            }
			
		}
	}
}
