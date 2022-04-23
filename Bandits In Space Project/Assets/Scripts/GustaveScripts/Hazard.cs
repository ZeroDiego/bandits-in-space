using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hazard : MonoBehaviour
{

    [SerializeField] protected int hazardDamage;
    protected bool hasBeenActivated;
    protected bool isVisible; 

    protected abstract int DoDamage();
   
}
