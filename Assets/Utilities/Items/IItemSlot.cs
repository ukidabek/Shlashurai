﻿namespace Utilities.Items
{
    public interface IItemSlot
    {
        IItem Item { get; set; }
        int Count { get; set; }
    }
}