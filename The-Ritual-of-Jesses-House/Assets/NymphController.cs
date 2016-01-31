using UnityEngine;
using System.Collections;

public class NymphController : MonoBehaviour 
{
    public NavMeshAgent navMeshAgent;
    private Vector3 targetLocation;
    private Quaternion targetRotation;
    private GameObject carriedObject;
    private Vector3 exitLocation;
    private float timeLeft;

    void Awake()
    {
        exitLocation = transform.position;
        timeLeft = 20.0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0.0f)
        {
            timeLeft = 20.0f;
            if(gameObject.tag != "Carrying")
            {
                navMeshAgent.Stop();
                navMeshAgent.ResetPath();
                navMeshAgent.gameObject.transform.position = exitLocation;
                navMeshAgent.gameObject.SetActive(false);
            }            
        }

        // massive nested statement to take care of nav mesh agent
        if (navMeshAgent.enabled && !navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0.0f)
                {
                    if(carriedObject != null)
                    {
                        ReturnToExitSpot();
                    }
                    else if(navMeshAgent.gameObject.tag == "Traveling")
                    {
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

    void ReturnToExitSpot()
    {
        // get rid of the object, no longer carrying it
        if(carriedObject != null)
        {
            carriedObject.transform.SetParent(null);
            carriedObject.transform.position = targetLocation;
            carriedObject.transform.rotation = targetRotation;
            carriedObject = null;

            navMeshAgent.gameObject.tag = "Untagged";
            navMeshAgent.Stop();
            navMeshAgent.ResetPath();
            navMeshAgent.SetDestination(exitLocation);
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
