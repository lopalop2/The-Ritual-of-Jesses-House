using UnityEngine;
using System.Collections;

public class NymphController : MonoBehaviour 
{
    public NavMeshAgent navMeshAgent;
    private Vector3 targetLocation;
    private Quaternion targetRotation;
    private GameObject carriedObject;
    private Vector3 exitLocation;

    void Awake()
    {
        exitLocation = transform.position;
    }

    void Update()
    {
        // massive nested statement to take care of nav mesh agent
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0.0f)
                {
                    if(carriedObject != null)
                    {
                        // get rid of the object, no longer carrying it
                        carriedObject.transform.SetParent(null);
                        carriedObject.transform.position = targetLocation;
                        carriedObject.transform.rotation = targetRotation;
                        carriedObject = null;

                        navMeshAgent.gameObject.tag = "Untagged";
                        navMeshAgent.SetDestination(exitLocation);
                    }
                    else
                    {
                        // has reached destination for exit
                        navMeshAgent.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        Pickupable pickup = coll.gameObject.GetComponent<Pickupable>();

        if (pickup == null)
            return;

        if(pickup.NymphPickup(gameObject))
        {
            navMeshAgent.Stop();
            navMeshAgent.ResetPath();

            targetLocation = pickup.GetNymphDestination();
            targetRotation = pickup.GetOriginalRotation();
            carriedObject = pickup.gameObject;

            navMeshAgent.SetDestination(pickup.GetNymphDestination());

            navMeshAgent.gameObject.tag = "Carrying";
        }
    }
}
