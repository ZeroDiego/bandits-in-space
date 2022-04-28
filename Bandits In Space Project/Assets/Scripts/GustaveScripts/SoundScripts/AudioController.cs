using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private void Update()
    {
        if (!gameObject.GetComponent<Toggle>().isOn)
        {
            AudioListener.volume = 0f; 
        }
        else
        {
            AudioListener.volume = 1f; 
        }
    }

}
