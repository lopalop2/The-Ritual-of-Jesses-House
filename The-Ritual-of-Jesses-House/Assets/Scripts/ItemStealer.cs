using UnityEngine;
using System.Collections;

public class ItemStealer : MonoBehaviour {

    public bool spawnSet;
    public bool hitFloor;
    public Vector3 spawnPos;
    public Vector3 force;
    public int count;
    public int maxCount;

    public Rigidbody rigid;
	// Use this for initialization
	void Start () 
    {

        spawnSet = false;
        hitFloor = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
        if(hitFloor == true && spawnSet == true)
        {
            ReturnToSpawn();
        }
	}

    void ReturnToSpawn()
    {


        if(count == maxCount)
        {

            gameObject.transform.position = spawnPos;
        }

        else if (count < maxCount)
        {

            count += 1;
        }
    }


    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Floor")
        {

            hitFloor = true;
         //   rigid.AddForce(force);
        }
    }


    void OnTriggerExit(Collider trig)
    {

        if(trig.gameObject.tag == "PickupSpawn" && spawnSet == false)
        {

            spawnPos = trig.gameObject.transform.position;
            spawnSet = true;
        }
    }
}
