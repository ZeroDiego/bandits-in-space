using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    public IEnumerator Shake()
    {
        Vector2 startPosition = gameObject.transform.position;
        float timeElapsed = 0f;
        float duration = 0.15f; 

        while(timeElapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * 0.4f;
            float y = Random.Range(-1f, 1f) * 0.4f;
            gameObject.transform.position = new Vector2(x, y);
            timeElapsed += Time.deltaTime;
            yield return 0; 
        }
        gameObject.transform.position = startPosition; 
    }
}
