using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pickupable : MonoBehaviour
{
    public virtual void Pickup(GameObject _player) 
    {
        gameObject.SetActive(false);
    }

    public void Drop(GameObject _player)
    {
        gameObject.SetActive(true);
    }
}
