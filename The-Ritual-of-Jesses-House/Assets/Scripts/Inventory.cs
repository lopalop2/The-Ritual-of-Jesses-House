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
    public GameObject selector;

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
		for (int i = 0; i < Size(); ++i)
        {
			if (items [i] == null)
			{
				items[i] = _item;	

                // check if other items are the same item
                for (int j = 0; j < Size(); ++j )
                {
                    if (j == i)
                        continue;

                    if (items[i] == items[j])
                        return;
                }

                if (i == 0)
                {
                    item1.sprite = _item.GetComponent<Image>().sprite;
                }
				if (i == 1) {
					item2.sprite = _item.GetComponent<Image> ().sprite;
				}
                return;
			}                
        }
    }

    public void SelectNextItem()
    {
        if(currItem == 0)
        {
            currItem = 1;
            Vector3 newPosition = selector.transform.position;
            newPosition.x = item2.transform.position.x;
            selector.transform.position = newPosition;
        }
        else
        {
            currItem = 0;
            Vector3 newPosition = selector.transform.position;
            newPosition.x = item1.transform.position.x;
            selector.transform.position = newPosition;
        }
       
    }

    public GameObject RemoveCurrItem()
    {
        if (currItem == 0)
            item1.sprite = null;
        else
            item2.sprite = null;

        GameObject ret = items[currItem];
        items[currItem] = null;
        return ret;
    }
}
