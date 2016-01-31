using UnityEngine;
using System.Collections;

public class charaController : MonoBehaviour 
{
    public float rotationDegreesPerSecond;
    public NymphSpawning nymphSpawning;

    int hashID_walking;

    Animator anim;
    Rigidbody rb;
	CharacterController cc;
	Vector3 moveDirection = Vector3.zero;
	public AudioSource walk;
	float speed = 2;
    Inventory inventory;
    private float dropKeyHoldTime;

	// Use this for initialization
	void Awake()
    {
        hashID_walking = Animator.StringToHash("isWalking");
        anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		cc = GetComponent<CharacterController>();
        inventory = GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
		if(anim.GetBool (hashID_walking) ? walk.mute = false : walk.mute = true);
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
		speed += Input.GetAxis ("Mouse ScrollWheel")  * 5;
		if (Input.GetAxisRaw("Fire1") != 0)
		{
			if (Input.GetAxisRaw ("Fire2") != 0)
				speed = 10;
			else if (Input.GetAxisRaw ("Fire3") != 0) {
				speed = 2;
			}
			}
        Movement(hor, ver);

        
		if(Input.GetAxisRaw("Drop") != 0)
        {
            GameObject droppedItem = inventory.RemoveCurrItem();
            if (droppedItem != null)
                droppedItem.GetComponent<Pickupable>().Drop(gameObject,nymphSpawning);
        }

		if(Input.GetAxisRaw("Switch Current Item") != 0)
        {
            inventory.SelectNextItem();
        }
	}

    void Movement(float _hor, float _ver)
    {
        //probably fails on stairs
		if (cc.isGrounded) {
        	if(_hor == 0.0f && _ver == 0.0f)
        	{
        	    anim.SetBool(hashID_walking, false);
				moveDirection = new Vector3 (0, moveDirection.y, 0);
        	}
        	else
        	{
        	    anim.SetBool(hashID_walking, true);
			
					moveDirection = new Vector3 (_hor , 0, _ver);
					//moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed;
			
        	   // rb.velocity = new Vector3(_hor * 5, rb.velocity.y, _ver * 5);
			
        	    // rotation
        	}   
		}
		if (!cc.isGrounded)
			moveDirection.y -= 20 * Time.deltaTime;
		cc.Move (moveDirection * Time.deltaTime);
		if (cc.velocity.x != 0 || cc.velocity.z != 0) {
			float maxDegreesDelta = rotationDegreesPerSecond * Time.deltaTime;
			Quaternion towards = Quaternion.LookRotation (new Vector3 (cc.velocity.x, 0, cc.velocity.z));
			transform.rotation = Quaternion.RotateTowards (transform.rotation, towards, maxDegreesDelta);
		}
		else
			anim.SetBool(hashID_walking, false);
    }
}
