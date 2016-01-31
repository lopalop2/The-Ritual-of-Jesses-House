using UnityEngine;
using System.Collections;

public class DropContainers : MonoBehaviour 
{
    public GameObject[] containers;

    public GameObject GetContainer()
    {
        foreach(GameObject container in containers)
        {
            if (!container.activeSelf)
                return container;
        }

        return null;
    }
}
