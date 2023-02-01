using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Logic.Items
{
    public interface IItemCollection<T> where T:IItemSlot
    {
        ReadOnlyCollection<T> Items { get; }
        void AddItem(IItem item, int count = 1);
        T Get(int index);
        IEnumerable<T> GetAll();
        bool HasItem(IItem item);
        Func<T> CreateSlot { get; }
    }
}