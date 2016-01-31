using UnityEngine;
using System.Collections;

public class oldManScript : MonoBehaviour {

	TextBubble bub;

	// Use this for initialization
	void Start () {
		bub = GetComponent<TextBubble> ();
		bub.SetString ("Find the thing!");
		Invoke ("FlyAway", 5f);
	}

	void FlyAway () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		Invoke ("Despawn", 3f);
	}

	void Despawn()
	{
		Destroy (gameObject);
	}
}
