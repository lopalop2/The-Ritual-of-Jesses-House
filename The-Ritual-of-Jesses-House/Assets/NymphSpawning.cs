using UnityEngine;
using System.Collections;

public class NymphSpawning : MonoBehaviour 
{
    public GameObject[] nymphs;
    public GameObject[] waypoints;
    public void Spawn(Vector3 _pickupLoc, Vector3 _returnLoc)
    {
        foreach(GameObject nymph in nymphs)
        {
            if (nymph.tag == "Carrying")
                continue;
        
            nymph.SetActive(true);
            NavMeshAgent agent = nymph.GetComponent<NavMeshAgent>();
            agent.Stop();
            agent.ResetPath();
        
            Vector3 farthestPoint = _pickupLoc;
            foreach(GameObject waypoint in waypoints)
            {
                if(Vector3.Distance(_pickupLoc, farthestPoint) < Vector3.Distance(_pickupLoc, waypoint.transform.position))
                    farthestPoint = waypoint.transform.position;
            }
        
            nymph.transform.position = farthestPoint;
            agent.SetDestination(_pickupLoc);
        
            break;
        }
        
    }
}
