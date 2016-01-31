using UnityEngine;
using System.Collections;

public class playerSpawn : MonoBehaviour {

	public GameObject[] playerPrefabs;
	public cameraScript camera;
	GameObject newObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Fire1") != 0 && Input.GetAxis ("Fire2") != 0 && Input.GetAxis ("Fire3") != 0) {
			newObj = Instantiate (playerPrefabs [Random.Range (0, playerPrefabs.Length)]);
			newObj.transform.position = transform.position;
			camera.playerTransform = newObj.transform;
		}
	}
}
