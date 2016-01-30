using UnityEngine;
using System.Collections;

public class charaController : MonoBehaviour 
{

    public Inventory inventory;
    public float rotationDegreesPerSecond;

    int hashID_walking;

    Animator anim;
    Rigidbody rb;

	// Use this for initialization
	void Awake()
    {
        hashID_walking = Animator.StringToHash("isWalking");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Movement(hor, ver);
	}

    void Movement(float _hor, float _ver)
    {
        //probably fails on stairs
        if(_hor == 0.0f && _ver == 0.0f)
        {
            anim.SetBool(hashID_walking, false);
        }
        else
        {
            anim.SetBool(hashID_walking, true);
            rb.velocity = new Vector3(_hor * 5, rb.velocity.y, _ver * 5);

            // rotation
            float maxDegreesDelta = rotationDegreesPerSecond * Time.deltaTime;
            Quaternion towards = Quaternion.LookRotation(rb.velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, towards, maxDegreesDelta);
        }       
    }
}
