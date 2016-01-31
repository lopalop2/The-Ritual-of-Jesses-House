using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Inventory
{
    public GameObject[] items;
	public Image item1;
	public Image item2;

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
		for (int i = 0; i < Size (); ++i)
			if (items [i] == null)
			{
				items[i] = _item;	
				_item.GetComponent<Image> ();
			}
    }

    public GameObject RemoveItem(int _index)
    {
        GameObject ret = items[_index];
        items[_index] = null;
        return ret;
    }
}
