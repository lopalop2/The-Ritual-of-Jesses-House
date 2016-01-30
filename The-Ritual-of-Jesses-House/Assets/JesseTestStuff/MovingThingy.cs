using UnityEngine;
using System.Collections;

public class MovingThingy : MonoBehaviour {


    [SerializeField]
    float distance;

    [SerializeField]
    float moved;

    [SerializeField]
    float speedx;

    [SerializeField]
    float speedy;

    [SerializeField]
    float speedz;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        gameObject.transform.position = new Vector3(transform.position.x+speedx, transform.position.y+speedy, transform.position.z+speedz);
        moved++;
        if(moved >= distance)
        {
            speedz = -speedz;
            speedy = -speedy;
            speedx = -speedx;
            moved = 0;
        }

    }

}
