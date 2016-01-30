using UnityEngine;
using System.Collections;

public class UseItem : MonoBehaviour 
{
    public KeyCode useKey;
    public GameObject player;
    public Inventory inventory;
    bool isPlayerUsing;

    void Awake()
    {
        isPlayerUsing = false;
    }

    void OnTriggerStay(Collider coll)
    {
        if (Input.GetKeyDown(useKey))
        {
            Pickupable pickupable = coll.gameObject.GetComponent<Pickupable>();

            Debug.Log(coll.gameObject.name);
            if (pickupable != null && !inventory.IsFull())
            {
                Debug.Log("Tried to pick up.");
                pickupable.Pickup(player);
                inventory.AddItem(coll.gameObject);
            }
            else
            {
                foreach (MonoBehaviour mb in coll.gameObject.GetComponents<MonoBehaviour>())
                    if (mb is IUsable)
                        (mb as IUsable).Use(player);
                    else
                        return;
            }
        }

        isPlayerUsing = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(useKey))
            isPlayerUsing = false;
    }
}
