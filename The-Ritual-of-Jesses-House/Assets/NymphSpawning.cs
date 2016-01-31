using UnityEngine;
using System.Collections;

public class NymphSpawning : MonoBehaviour 
{
    public GameObject player;
    public GameObject[] nymphs;
    public GameObject[] waypoints;

    public void Update()
    {
        foreach(GameObject waypoint in waypoints)
        {
            Vector3 newPosition = waypoint.transform.position;
            newPosition.y = player.transform.position.y + 0.3f;
            waypoint.transform.position = newPosition;
        }
    }
    
    public void Spawn(Vector3 _pickupLoc, Vector3 _returnLoc)
    {
        int sent = 0;
        foreach(GameObject nymph in nymphs)
        {
            if (nymph.tag == "Carrying" || nymph.tag == "Traveling")
                continue;
        
            nymph.SetActive(true);
            NavMeshAgent agent = nymph.GetComponent<NavMeshAgent>();
            agent.Stop();
            agent.ResetPath();
            nymph.tag = "Traveling";
        
            Vector3 farthestPoint = _pickupLoc;
            foreach(GameObject waypoint in waypoints)
            {
                if(Vector3.Distance(_pickupLoc, farthestPoint) < Vector3.Distance(_pickupLoc, waypoint.transform.position))
                    farthestPoint = waypoint.transform.position;
            }
        
            nymph.transform.position = farthestPoint;
            _pickupLoc.x = _pickupLoc.x + sent * 0.5f - 0.25f;
            agent.SetDestination(_pickupLoc);
            
            if(++sent == 3)
                break;
        }
        
    }
}
