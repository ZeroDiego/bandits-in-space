using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class AnimatorController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>(); 
    }
    private void Update()
    {
        
    }
}
