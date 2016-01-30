using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

    public Transform playerTransform;
    public Vector3 offSet;

	void FixedUpdate()
    {
        transform.position = playerTransform.position + offSet;
    }
	
}
