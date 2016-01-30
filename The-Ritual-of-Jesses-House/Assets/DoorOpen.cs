using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, IUsable {

    [SerializeField]
    bool test = false;
	// Use this for initialization
	void Start () {
	
	}
	public void Use(GameObject _player)
    {
        if(!test)
        {
            gameObject.transform.localRotation = new Quaternion(0, 45, 0, 0);
            test = true;
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
            test = false;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}

}
