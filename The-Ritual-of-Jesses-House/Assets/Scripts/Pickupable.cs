using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour
{
    public void Pickup(GameObject _player) 
    {
        gameObject.SetActive(false);
    }
}
