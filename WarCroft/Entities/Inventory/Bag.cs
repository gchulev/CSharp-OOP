using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private readonly List<Item> items;
        public Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }

        public int Capacity { get => this.capacity; set => this.capacity = value; }

        public int Load => this.Items.Sum(item => item.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load >= this.Capacity)
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
            Item desiredItem = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (desiredItem is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(desiredItem);
            return desiredItem;
        }
    }
}
