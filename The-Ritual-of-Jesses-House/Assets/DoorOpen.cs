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
            }
        }
        if (!locked)
        {

            if (!test)
            {
                gameObject.transform.localRotation = new Quaternion(0, 45, 0, 0);
                test = true;
            }
            else
            {
                if (!doubledoor)
                    gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
                else
                    gameObject.transform.localRotation = Quaternion.Euler(0, 270, 0);

                test = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
