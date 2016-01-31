using UnityEngine;
using System.Collections;

public class UseItem : MonoBehaviour 
{
    public KeyCode useKey;
    public GameObject player;
    public Inventory inventory;
    private Animator anim;
    bool isPlayerUsing;

    void Awake()
    {
        isPlayerUsing = false;
        anim = player.GetComponent<Animator>();
    }

    IEnumerator OnTriggerStay(Collider coll)
    {
		if (Input.GetButtonDown("Interact"))
        {
            Pickupable pickupable = coll.gameObject.GetComponent<Pickupable>();

            Debug.Log(coll.gameObject.name);
            if (pickupable != null && !inventory.IsFull())
            {
                anim.SetBool("isAction", true);
                yield return new WaitForSeconds(0.5f);
                if(!inventory.IsFull())
                    pickupable.Pickup(player);
                inventory.AddItem(coll.gameObject);
            }
            else
            {
                foreach (MonoBehaviour mb in coll.gameObject.GetComponents<MonoBehaviour>())
                    if (mb is IUsable)
                        (mb as IUsable).Use(player);
                    else
                        yield return null;
            }
        }

        isPlayerUsing = true;
    }

    void Update()
    {
		if (Input.GetButtonUp("Interact"))
            isPlayerUsing = false;
    }
}
