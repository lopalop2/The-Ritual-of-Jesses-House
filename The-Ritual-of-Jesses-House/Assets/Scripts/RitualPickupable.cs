using UnityEngine;
using System.Collections;

public class RitualPickupable : Pickupable
{
    public Vector3 dropPoint;
    public Vector3 ritualArea;
    public float distance;
    public RitualController ritual;

    private bool Placed = false;

    public override void Pickup(GameObject _player)
    {
        if(Placed == true)
        {
            Placed = false;
            ritual.ItemRemoved();
        }

        gameObject.SetActive(false);
    }

    public override void Drop(GameObject _player, NymphSpawning _nymphSpawning)
    {
        Vector3 initPos = gameObject.transform.position;
        Vector3 dropToPos = _player.transform.position;


        if (Vector3.Distance(_player.transform.position, ritualArea) > distance)
        {
            if (_player.transform.position.y < 4.21f)
            {
                dropToPos.y = 0.415f;
            }

            gameObject.transform.position = dropToPos;

            gameObject.SetActive(true);
            _nymphSpawning.Spawn(dropToPos, initPos);
            isDropped = true;
        }
        else
        {
            gameObject.transform.position = dropPoint;
            Placed = true;
            gameObject.SetActive(true);
            ritual.ItemComplete();
        }
    }
}
