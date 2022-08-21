using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private Stack<Item> itemPool;

		public WarController() 
		{
			this.party = new List<Character>();
			this.itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string charType = args[0];
			string charName = args[1];

			if (charType != "Warrior" && charType != "Priest")
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.InvalidCharacterType, charType));
			}

			if (charType == "Warrior")
            {
				this.party.Add(new Warrior(charName));
            }
			else if (charType == "Priest")
            {
				this.party.Add(new Priest(charName));
            }

			return String.Format(SuccessMessages.JoinParty, charName);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			if (itemName != "HealthPotion" && itemName != "FirePotion")
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			if (itemName == "HealthPotion")
            {
				this.itemPool.Push(new HealthPotion());
            }
			else if (itemName == "FirePotion")
            {
				this.itemPool.Push(new FirePotion());
            }

			return String.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string charName = args[0];

			Character character = this.party.FirstOrDefault(x => x.Name == charName);

			if (character == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, charName));
			}

			if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item lastItemInPool = itemPool.Pop();
			character.Bag.AddItem(lastItemInPool);

			return String.Format(SuccessMessages.PickUpItem, charName, lastItemInPool.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string charName = args[0];
			string itemName = args[1];

			Character character = this.party.FirstOrDefault(x => x.Name == charName);

			if (character == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, charName));
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return String.Format(SuccessMessages.UsedItem, charName, itemName);
		}

		public string GetStats()
        {
            var sb = new StringBuilder();

            List<Character> sortedCharacters = this.party
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health)
                .ToList();

            foreach (var character in sortedCharacters)
            {
                string aliveOrDead = string.Empty;

                if (character.IsAlive)
                {
                    aliveOrDead = "Alive";
                }
                else
                {
                    aliveOrDead = "Dead";
                }

                sb.AppendLine(String.Format
                    (SuccessMessages.CharacterStats,
                     character.Name,
                     character.Health,
                     character.BaseHealth,
                     character.Armor,
                     character.BaseArmor,
                     aliveOrDead)
                    );
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			var sb = new StringBuilder();

			Character attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

			if (attacker == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}

			if (receiver == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			if (attacker.GetType().Name != "Warrior")
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.AttackFail, attackerName));
			}

			

			((IAttacker)attacker).Attack(receiver);

			sb.AppendLine(String.Format(
				SuccessMessages.AttackCharacter,
				attackerName,
				receiverName,
				attacker.AbilityPoints,
				receiverName,
				receiver.Health,
				receiver.BaseHealth,
				receiver.Armor,
				receiver.BaseArmor));

			if (!receiver.IsAlive)
            {
				sb.AppendLine(String.Format(
					SuccessMessages.AttackKillsCharacter,
					receiverName));
            }

			return sb.ToString().TrimEnd();
		}

        public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			var sb = new StringBuilder();

			Character healer = this.party.FirstOrDefault(x => x.Name == healerName);
			Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

			if (healer == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}

			if (receiver == null)
			{
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

			if (healer.GetType().Name != "Priest")
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

			((IHealer)healer).Heal(receiver);

			sb.AppendLine(String.Format(
				SuccessMessages.HealCharacter,
				healerName,
				healingReceiverName,
				healer.AbilityPoints,
				healingReceiverName,
				receiver.Health));

			return sb.ToString().TrimEnd();
		}
	}
}
