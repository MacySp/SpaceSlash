using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnAwake : MonoBehaviour
{
    public AudioClip sound;
    public float Volume = 1.0f;
    private AudioSource objectAudio;
    public bool useArray = false;
    public AudioClip[] soundsamples;
    // Start is called before the first frame update
    void Start()
    {
        objectAudio = GetComponent<AudioSource>();
        if (useArray)
        {
            int audioIndex = Random.Range(0, soundsamples.Length);
            objectAudio.PlayOneShot(soundsamples[audioIndex],Volume);
        }
        else {
            objectAudio.PlayOneShot(sound, Volume); }
    }


}
