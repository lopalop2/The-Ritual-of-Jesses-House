using UnityEngine;
using System.Collections;

public class GrabItem : MonoBehaviour
{

    Inventory inv;

    void Awake()
    {
        inv = GetComponent<Inventory>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision _col)
    {
        if (_col.gameObject.tag == "Pickups" && Input.GetKeyDown(KeyCode.E))
            inv.AddItem(_col.gameObject);
    }
}
