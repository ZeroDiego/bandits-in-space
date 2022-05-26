using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude) 
    {
        Vector3 startPosition = gameObject.transform.localPosition;
        float timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            gameObject.transform.localPosition = new Vector3(x, y, startPosition.z);

            timeElapsed += Time.deltaTime; 
            yield return null; 
        }
        gameObject.transform.localPosition = startPosition; 
    }   
}
