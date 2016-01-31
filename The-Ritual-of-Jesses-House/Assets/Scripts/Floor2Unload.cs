using UnityEngine;
using System.Collections;

public class Floor2Unload : MonoBehaviour
{

    [SerializeField]
    GameObject Floor2;

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
        if (_col.gameObject.tag == "Player")
        {
            Floor2.SetActive(false);
        }
    }
}
