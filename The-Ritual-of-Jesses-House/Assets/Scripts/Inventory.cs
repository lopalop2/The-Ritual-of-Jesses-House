using UnityEngine;
using System.Collections;

[System.Serializable]
public class Inventory
{
    public GameObject[] items;

    public int Size() { return items.Length; }

    public bool IsFull()
    {
        foreach (GameObject item in items)
            if (item == null)
                return true;

        return false;
    }

    public void AddItem(GameObject _item)
    {
        for (int i = 0; i < Size(); ++i)
            if (items[i] == null)
                items[i] = _item;
    }

    public GameObject RemoveItem(int _index)
    {
        GameObject ret = items[_index];
        items[_index] = null;
        return ret;
    }
}
