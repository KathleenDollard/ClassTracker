using System;
using System.Collections.Generic;

namespace KadGen.Common.Repository
{
    public class BaseFactory<T>
    {
        private Dictionary<Type, T> _items { get; }

        protected BaseFactory(Dictionary<Type, T> items)
        {
            _items = items;
        }

        public T this[Type type] => _items[type];
    }
}
