using UnityEngine;
using System.Collections;

public class Floor2Trigger : MonoBehaviour
{


    [SerializeField]
    GameObject Floor2 = null;

    //Make sure player is tagged as such!
    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            Floor2.SetActive(true);
        }
    }
}
