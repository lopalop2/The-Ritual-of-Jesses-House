using UnityEngine;
using System.Collections;

public class TriggeredMove : MonoBehaviour
{

    [SerializeField]
    float distance = 0;

    [SerializeField]
    float moved = 0;

    [SerializeField]
    float speed = 0;

    [SerializeField]
    bool isX = false;

    [SerializeField]
    bool isY = false;

    [SerializeField]
    bool isZ = false;

    [SerializeField]
    bool moving = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move();
        }
    }

    void FixedUpdate()
    {
        //if (moving)
        //{
        //    Move();
        //}
    }

    void Move()
    {
        if (isX && moved < distance)
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (isY && moved < distance)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
        if (isZ && moved < distance)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }
    }

    public void SetMove()
    {
        moving = true;
    }
}
