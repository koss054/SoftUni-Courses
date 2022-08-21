using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
		private double armor;

		// May need to change Bag to IBag if the result isn't 100/100
		protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
        }

		public string Name
        {
			get
            {
				return this.name;
            }
			private set
            {
				if (String.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}

				this.name = value;
            }
        }

		public double BaseHealth { get; private set; }

		public double Health
        {
			get
            {
				return this.health;
            }
			set
            {
				this.health = value;

				if (this.health < 0)
                {
					this.health = 0;
                }

				if (this.health > this.BaseHealth)
                {
					this.health = this.BaseHealth;
                }
            }
        }

		public double BaseArmor { get; private set; }

		public double Armor
        {
			get
            {
				return this.armor;
            }
			private set
            {
				this.armor = value;

				if (this.armor < 0)
                {
					this.armor = 0;
                }

				if (this.armor > this.BaseArmor)
                {
					this.armor = this.BaseArmor;
                }
            }
        }

		public double AbilityPoints { get; private set; }

		// May need to change Bag to IBag if the result isn't 100/100
		public Bag Bag { get; private set; }

		public bool IsAlive { get; set; } = true;

		public void TakeDamage(double hitPoints)
        {
			if (this.IsAlive)
            {
				double hitPointsAfterHittingArmor = hitPoints - this.Armor;
				this.Armor -= hitPoints;

				if (hitPointsAfterHittingArmor > 0)
                {
					this.Armor = 0;
					this.Health -= hitPointsAfterHittingArmor;
                }

				if (this.Health <= 0)
                {
					this.IsAlive = false;
                }
            }
        }

		public void UseItem(Item item)
        {
			if (!this.IsAlive)
            {
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}

			item.AffectCharacter(this);
        }

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}