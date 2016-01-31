using UnityEngine;
using System.Collections;

public class SimulatedCuling : MonoBehaviour
{

    GameObject wall;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnColissionStay(Collision _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            wall.gameObject.SetActive(false);
        }
    }

    void OnColissionExit(Collision _col)
    {
        wall.gameObject.SetActive(true);
    }

}
