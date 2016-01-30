using UnityEngine;
using System.Collections;

public class charaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (Input.GetAxis ("Horizontal"), GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);
		}
		if (Input.GetAxis ("Vertical") != 0) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x, GetComponent<Rigidbody> ().velocity.y, Input.GetAxis ("Vertical"));
		}
	}
}
