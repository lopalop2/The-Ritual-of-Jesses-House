using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] items;
	public Image item1;
	public Image item2;

    private int currItem = 0;

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
		for (int i = 0; i < Size (); ++i){
			if (items [i] == null)
			{
				items[i] = _item;	

				if (i == 0) {
					item1.sprite = _item.GetComponent<Image> ().sprite;
				}
				if (i == 1) {
					item2.sprite = _item.GetComponent<Image> ().sprite;
				}
			}
                return;
            }
    }

    public void SelectNextItem()
    {
        currItem = currItem == 0 ? 1 : 0;
    }

    public GameObject RemoveCurrItem()
    {
        GameObject ret = items[currItem];
        items[currItem] = null;
        return ret;
    }
}
