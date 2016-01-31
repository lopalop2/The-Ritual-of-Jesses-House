using UnityEngine;
using System.Collections;

public class ActionTrigger : MonoBehaviour
{

    GameObject ActionItem = null;

    TriggeredMove mover;

    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
        mover = ActionItem.GetComponent<TriggeredMove>();

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnColissionStay(Collision _col)
    {
        if (Input.GetKeyDown(KeyCode.E) && _col.gameObject.tag == "Player")
            mover.SetMove();
    }
}
