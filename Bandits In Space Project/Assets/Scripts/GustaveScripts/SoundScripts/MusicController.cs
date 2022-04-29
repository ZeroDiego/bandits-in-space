using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float loopEndPoint;
    public float loopStartPoint;
    public AudioSource currentTrack;
    public AudioSource silentTrack; 

    private void Awake()
    {
        if (gameObject.CompareTag("Music"))
        {
            currentTrack = gameObject.GetComponent<AudioSource>();
        } else if(gameObject.name == "MusicLoop")
        {
            silentTrack = gameObject.GetComponent<AudioSource>(); 
        }
        
    }

    private void Update()
    {
        if(currentTrack.time >= loopEndPoint)
        {
            currentTrack.time = loopStartPoint; 
        } 
    }

}
