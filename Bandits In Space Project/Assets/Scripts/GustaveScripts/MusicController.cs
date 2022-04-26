using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float loopPoint;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(gameObject.GetComponent<AudioSource>().time >= loopPoint)
        {
//loopedAudioClip.Play(); 
        } 
    }

}
