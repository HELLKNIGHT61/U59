using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudSys : MonoBehaviour
{
   private AudioSource audioScr;
   private float musicVolume=0.5f;

    void Start()
    {
        audioScr = GetComponent<AudioSource>();

    }

     void Update()
    {
        audioScr.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
    

}