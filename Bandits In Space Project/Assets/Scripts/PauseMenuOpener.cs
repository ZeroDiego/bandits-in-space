using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuOpener : MonoBehaviour {

    public GameObject PauseMenu;

    public void openPauseMenu()
    {
        if(PauseMenu != null)
        {
            PauseMenu.SetActive(true);
        }

    }
}