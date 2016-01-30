using UnityEngine;
using System.Collections;

public class StormController : MonoBehaviour
{
    [SerializeField]
    AudioSource RainAudio = null;
    [SerializeField]
    AudioSource ThunAudio = null;

    [SerializeField]
    AudioClip rain = null;
    [SerializeField]
    AudioClip thunder = null;

    float volume = 0.1f;

    void Awake()
    {
        RainAudio.volume = volume;
        ThunAudio.volume = volume * 3;
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
}
