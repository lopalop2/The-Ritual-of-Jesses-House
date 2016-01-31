using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

    public Transform playerTransform;
    public Vector3 offSet;

	void Update()
    {
        transform.position = playerTransform.position + offSet;
    }


}
