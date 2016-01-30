using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GameObject[] items;
    public Image uiItem0;
    public Image uiItem1;

    public int Size() { return items.Length; }

    public bool IsFull()
    {
        foreach (GameObject item in items)
            if (item == null)
                return false;

        return true;
    }

    public void AddItem(GameObject _item)
    {
        for (int i = 0; i < Size(); ++i)
            if (items[i] == null)
            {
                items[i] = _item;
                return;
            }
    }

    public GameObject RemoveItem(int _index)
    {
        GameObject ret = items[_index];
        items[_index] = null;
        return ret;
    }
}
