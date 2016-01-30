﻿using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (Input.GetAxis ("Horizontal") * 5, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);
		}
		if (Input.GetAxis ("Vertical") != 0) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x, GetComponent<Rigidbody> ().velocity.y, Input.GetAxis ("Vertical") * 5);
		}
		if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0)
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
