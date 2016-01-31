using UnityEngine;
using System.Collections;

public class ToggleParticle : MonoBehaviour, IUsable {

    ParticleSystem part;

	// Use this for initialization
	void Awake () {
        part = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Use(GameObject _player)
    {
        part.maxParticles = 0;
    }
}
