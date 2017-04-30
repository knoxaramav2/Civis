using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FieldMenu : MonoBehaviour
{
    public GameObject DropMenu;
    public GameObject Indicator;

	// Use this for initialization
	void Start () {
		
	}

    //Menu Options
    public void OpenDropMenu()
    {
        DropMenu.SetActive(true);
    }

    public void CloseDropMenu()
    {
        DropMenu.SetActive(false);
    }

    public void ToggleMenu()
    {
        if (DropMenu.activeSelf)
            CloseDropMenu();
        else
            OpenDropMenu();
    }


    //Quit Options
    public void QuitToDesktop()
    {
        
    }

    public void QuitToLobby()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
