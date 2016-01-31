using UnityEngine;
using System.Collections;

public class playerSpawn : MonoBehaviour {

	public GameObject[] playerPrefabs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Fire1") != 0 &&Input.GetAxis("Fire2") != 0 &&Input.GetAxis("Fire3") != 0)
			Instantiate(playerPrefabs[Random.Range(0,playerPrefabs.Length)]);
	}
}
