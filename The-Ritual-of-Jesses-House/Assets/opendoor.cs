using UnityEngine;
using System.Collections;

public class opendoor : MonoBehaviour, IUsable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use(GameObject Player){
		gameObject.transform.Rotate(Vector3.right);
	}
}
