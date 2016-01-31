using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, IUsable {

    [SerializeField]
	bool test = false;
	[SerializeField]
	bool locked = false;
	[SerializeField]
	string ItemName = "Name of item used as key";
	[SerializeField]
	bool doubledoor = false;
	public Inventory plyinv;
	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		
	}
	public void Use(GameObject _player)
	{
		if (locked) {
			plyinv = _player.GetComponent<Inventory> ();
			if (plyinv) {
				for (int i = 0; i < plyinv.Size (); i++) {
					if (plyinv.items [i] != null) {
						if (plyinv.items [i].name == ItemName) {
							locked = false;
							break;
						}
					}
				}
			}
		}
		if (!locked) {
			if (!test) {
				gameObject.transform.localRotation = new Quaternion (0, 45, 0, 0);
				test = true;
			} else {
				if (!doubledoor)
					gameObject.transform.localRotation = Quaternion.Euler (0, 90, 0);
				else
					gameObject.transform.localRotation = Quaternion.Euler (0, 270, 0);
		
			test = false;
			}
		}
    }
	// Update is called once per frame
	void Update () {
	
	}

}
