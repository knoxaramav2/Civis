using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FieldMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject Indicator;
    public GameObject ViewMenu;

	// Use this for initialization
	void Start () {
		ViewMenu.SetActive(false);
        MenuPanel.SetActive(false);
	}

    //Menu Options
    public void OpenDropMenu()
    {
        MenuPanel.SetActive(true);
    }

    public void CloseDropMenu()
    {
        MenuPanel.SetActive(false);
    }

    public void ToggleMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }

    public void OpenViewMenu()
    {
        ViewMenu.SetActive(true);
    }

    public void CloseViewMenu()
    {
        ViewMenu.SetActive(false);
    }

    public void ToggleViewMenu()
    {
        ViewMenu.SetActive(!ViewMenu.activeSelf);
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
