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
    public GameObject ActionPanel;

    private Button _actionButton;

	// Use this for initialization
	void Start () {
		ViewMenu.SetActive(false);
        MenuPanel.SetActive(false);

	    _actionButton = ActionPanel.GetComponentInChildren<Button>();
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

    //Action Panel Options
    public void ShowActionPanel()
    {
        ActionPanel.SetActive(true);
    }

    public void HideActionPanel()
    {
        ActionPanel.SetActive(false);
    }

    public void SetActionButton(string msg)
    {
        _actionButton.GetComponentInChildren<Text>().text = msg;
    }

    public void ActionButtonPressed()
    {
        
    }

    //Action Panel Options
    public void ShowActionMenu()
    {
        
    }

    public void HideActionMenu()
    {
        
    }

    public void AddActionButton()
    {
        
    }

    public void TriggerActionButton(string msg)
    {
        //var tb = new Button(msg);
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
