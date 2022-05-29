using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfPlayers : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Victory.numberOfLevelsComplete < 1)
        {
            player2.SetActive(false);
            player3.SetActive(false); 
        } 
        else if(Victory.numberOfLevelsComplete == 1)
        {
            player2.SetActive(true);
            player3.SetActive(false); 
        }
        else
        {
            player3.SetActive(true); 
        }
    }
}
