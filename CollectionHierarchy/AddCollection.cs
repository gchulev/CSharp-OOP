using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> _internalCollection;

        public AddCollection()
        {
            this._internalCollection = new List<string>();
        }

        public IReadOnlyCollection<string> InternalCollection
        {
            get
            {
                return this._internalCollection;
            }
        }
        public int Add(string item)
        {
            this._internalCollection.Add(item);
            return this._internalCollection.Count - 1;
        }
    }
}
