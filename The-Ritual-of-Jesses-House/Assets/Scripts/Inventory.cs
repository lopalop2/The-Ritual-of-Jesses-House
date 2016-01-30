using UnityEngine;
using System.Collections;

[System.Serializable]
public class Inventory
{
    public Item[] items;

    public int Size() { return items.Length; }

    public bool IsFull()
    {
        foreach (Item item in items)
            if (item == null)
                return true;

        return false;
    }

    public void AddItem(Item _item)
    {
        for (int i = 0; i < Size(); ++i)
            if (items[i] == null)
                items[i] = _item;
    }

    public Item RemoveItem(int _index)
    {
        Item ret = items[_index];
        items[_index] = null;
        return ret;
    }
}
