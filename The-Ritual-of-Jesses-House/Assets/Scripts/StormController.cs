using UnityEngine;
using System.Collections;

public class StormController : MonoBehaviour
{
    [SerializeField]
    AudioSource RainAudio = null;
    [SerializeField]
    AudioSource ThunAudio = null;
	[SerializeField]
	AudioSource squeakAudio = null;


    [SerializeField]
    AudioClip rain = null;
    [SerializeField]
    AudioClip thunder = null;
	[SerializeField]
	AudioClip squeak = null;

    float volume = 0.1f;

    void Awake()
    {
		volume = PlayerPrefs.GetFloat ("Volume");
		RainAudio.volume = volume;
		squeakAudio.volume = volume;
        ThunAudio.volume = volume * 3;
		Invoke ("Squeak", Random.Range (0, 5));
    }


    // Update is called once per frame
    void Update()
    {
        Rain();
    }

    void Rain()
    {
        if (!RainAudio.isPlaying)
            RainAudio.PlayOneShot(rain);
        if (Random.Range(0, 500) == 100)
            Thunder();
    }

    void Thunder()
    {
        ThunAudio.PlayOneShot(thunder);
    }

	void Squeak()
	{
		if (squeakAudio.mute) {
			squeakAudio.mute = false;
			Invoke ("Squeak", Random.Range (0, 5));
		} else {
			squeakAudio.mute = true;
			Invoke ("Squeak", Random.Range (5, 20));
		}
	}
}
