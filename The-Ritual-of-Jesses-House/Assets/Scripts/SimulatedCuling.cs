using UnityEngine;
using System.Collections;

public class SimulatedCuling : MonoBehaviour
{
    //Culling**
    [SerializeField]
    GameObject wall = null;

    MeshRenderer rend = null;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        rend = wall.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            rend.enabled = false;
        }
    }

    void OnTriggerExit(Collider _col)
    {
        if(_col.gameObject.tag == "Player")
        rend.enabled = true;
    }
}
