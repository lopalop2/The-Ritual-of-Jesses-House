using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, IUsable
{

    Inventory plyinv;
    bool test = false;
    [SerializeField]
    bool locked = false;
    [SerializeField]
    string ItemName = "Name of item used as key";
    [SerializeField]
    bool doubledoor = false;
    [SerializeField]
    bool Destructable = false;

    bool destroyed = false;
    [SerializeField]
    GameObject[] items2;

	AudioSource audio = null;

	[SerializeField]
	AudioClip lockedclip= null;

	[SerializeField]
	AudioClip unlockclip= null;

	[SerializeField]
	AudioClip breakdownclip = null;

	[SerializeField]
	AudioClip closeclip = null;

    [SerializeField]
    int x = 0;
    [SerializeField]
    int y = 0;
    [SerializeField]
    int z = 0;
    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
		audio = GetComponentInParent<AudioSource> ();
    }
    public void Use(GameObject _player)
    {
        if (destroyed)
            return;
        if (locked)
        {
            plyinv = _player.GetComponent<Inventory>();
            if (plyinv)
            {
                for (int i = 0; i < plyinv.Size(); i++)
                {
                    if (plyinv.items[i] != null)
                    {
                        for (int k = 0; k < items2.Length; k++)
                        {
                            if (plyinv.items[i].name == items2[k].name)
                            {
                                if (Destructable)
                                {
                                    //DestroyObject(gameObject);
                                    if (plyinv.items[i].name != "sledge")
                                    {
                                        plyinv.items[i] = null;
                                    }
									if(!audio.isPlaying)
										audio.PlayOneShot (breakdownclip);
                                    gameObject.transform.localRotation = Quaternion.Euler(x, y, z);
                                    destroyed = true;
                                    return;
                                }
                            }
                        }
                        if (plyinv.items[i].name == ItemName)
                        {
                            locked = false;
                            break;
                        }
                    }
                }
				if(!audio.isPlaying)
					audio.PlayOneShot (lockedclip);

            }
        }
        if (!locked)
        {

            if (!test)
            {
                gameObject.transform.localRotation = new Quaternion(0, 45, 0, 0);
				if(!audio.isPlaying)
					audio.PlayOneShot (unlockclip);
                test = true;
            }
            else
            {
                if (!doubledoor)
                    gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
                else
                    gameObject.transform.localRotation = Quaternion.Euler(0, 270, 0);


				if(!audio.isPlaying)
					audio.PlayOneShot (closeclip);
                test = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
