using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pickupable : MonoBehaviour
{
    const float dropDistance = 0.5f;
    Vector3 originalLocation;
    Quaternion originalRotation;
    protected bool isDropped;

    void Awake()
    {
        originalLocation = transform.position;
        originalRotation = transform.rotation;
    }
    public virtual void Pickup(GameObject _player) 
    {
        gameObject.SetActive(false);
    }

    public virtual void Drop(GameObject _player, NymphSpawning _nymphSpawning)
    {
        Vector3 initPos = gameObject.transform.position;
        Vector3 dropToPos = _player.transform.position;

        if (_player.transform.position.y < 4.21f)
        {
            dropToPos.y = 0.415f;
        }

        gameObject.transform.position = dropToPos;
        
        gameObject.SetActive(true);
        _nymphSpawning.Spawn(dropToPos, initPos);
        isDropped = true;
    }

    public bool NymphPickup(GameObject _nymph)
    {
        if (isDropped)
        {
            gameObject.transform.SetParent(_nymph.transform);
            isDropped = false;
            return true;
        }

        return false;
    }

    public Vector3 GetNymphDestination() { return originalLocation; }
    public Quaternion GetOriginalRotation() { return originalRotation; }
}
