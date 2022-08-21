using System;
using System.Linq;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public int Load
            => this.items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item searchedItem = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (searchedItem == null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(searchedItem);

            return searchedItem;
        }
    }
}
