using UnityEngine;
using System.Collections;

public class playerSpawn : MonoBehaviour {

	public GameObject[] playerPrefabs;
	public cameraScript camera;
    public NymphSpawning nymphSpawning;
    public GameObject currentPlayer;

	// Use this for initialization
	void Awake () 
    {
        AssignRandomPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Fire1") != 0 && Input.GetAxis ("Fire2") != 0 && Input.GetAxis ("Fire3") != 0) {
            AssignRandomPlayer();
		}
	}

    void AssignRandomPlayer()
    {
        Debug.Log("Assigning Random Player.");
        currentPlayer.SetActive(false);
        currentPlayer = playerPrefabs[Random.Range(0, playerPrefabs.Length)];
        currentPlayer.transform.position = transform.position;
        camera.playerTransform = currentPlayer.transform;
        nymphSpawning.player = currentPlayer;
        currentPlayer.SetActive(true);
    }
}
