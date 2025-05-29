using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public Stamina stamina;
    public AudioClip audioClip;
    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(stamina.stamina <= 125 && !audioSource.isPlaying)
        {           
            audioSource.Play();
        }
        else if(stamina.stamina > 125)
        {
            audioSource.Stop(); 
        }

        
    }
}
