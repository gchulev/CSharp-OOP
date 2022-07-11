using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private readonly List<string> _internalCollection;

        public MyList()
        {
            this._internalCollection = new List<string>();
        }

        public int Used { get => this._internalCollection.Count; }
        public IReadOnlyCollection<string> InternalCollection { get => this._internalCollection; }
        public int Add(string item)
        {
            this._internalCollection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string elmToRemove = this._internalCollection[0];
            if (elmToRemove != null)
            {
                this._internalCollection.RemoveAt(0);
            }
            return elmToRemove;
        }
    }
}
