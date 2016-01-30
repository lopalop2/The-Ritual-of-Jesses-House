using UnityEngine;
using System.Collections;

public class Floor2Trigger : MonoBehaviour
{


    [SerializeField]
    GameObject Floor2 = null;

    bool isFloor2 = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
