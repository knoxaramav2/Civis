﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
	// Use this for initialization
	void Start () {

        //IMPORTANT -- TempState must be destroyed when game ends -- all ended games return here
        var state = GameObject.FindGameObjectWithTag("TempState");

	    if (state != null)
	    {
            Destroy(state);
	    }

	    state = new GameObject("Session") { tag = "TempState" };
	    state.AddComponent<Session>();
	    DontDestroyOnLoad(state);
	}

    public void StartNewGame()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Switched to load scene");
        SceneManager.LoadScene("GameLoad");
    }
}
