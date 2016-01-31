using UnityEngine;
using System.Collections;

public class Floor2Trigger : MonoBehaviour
{


    [SerializeField]
    GameObject Floor2 = null;

    bool isFloor2 = false;

    //Make sure player is tagged as such!
    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Player" && !isFloor2)
        {
            Floor2.SetActive(true);
            isFloor2 = true;
        }
        else if(_col.gameObject.tag == "Player" && isFloor2)
        {
            Floor2.SetActive(false);
            isFloor2 = false;
        }
    }
}
