using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> _internalCollection;

        public AddRemoveCollection()
        {
            this._internalCollection = new List<string>();
        }

        public IReadOnlyCollection<string> InternalCollection { get => this._internalCollection; }
        public int Add(string item)
        {
            this._internalCollection.Insert(0, item);
            return 0;
        }
        public string Remove()
        {
            var itemToRemove = this._internalCollection[^1];
            if (itemToRemove != null)
            {
                this._internalCollection.RemoveAt(this._internalCollection.IndexOf(itemToRemove));
            }
            return itemToRemove;
        }


    }
}
