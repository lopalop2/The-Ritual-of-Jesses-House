using UnityEngine;
using System.Collections;

public class ActionTrigger : MonoBehaviour, IUsable
{

    GameObject ActionItem = null;

    [SerializeField]
    TriggeredMove mover;

    void Awake()
    {
        mover = ActionItem.GetComponent<TriggeredMove>();
    }
    public void Use(GameObject _player)
    {
        mover.SetMove();
    }
}
