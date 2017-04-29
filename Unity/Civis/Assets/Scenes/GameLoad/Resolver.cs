using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resolver : MonoBehaviour
{
    private GameObject  _dataShuttle;
    private Session     _session;
    private Map         _map;
    private Text        _text;

	// Use this for initialization
	void Start () {
	    _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
	    _session = _dataShuttle.GetComponent<Session>();
	    _map = _dataShuttle.AddComponent<Map>();
	    _text = GameObject.Find("WaitText").GetComponent<Text>();

	    if (_session.IsNewGame)
	    {
	        _text.text = "Creating New Game";
	        GenerateNewGameInfo();
	    }
	    else
	    {
	        _text.text = "Loading Game";
            LoadGameInfo();
	    }
	        
        AssembleMapData();


        SceneManager.LoadScene("Field");
	}

    void GenerateNewGameInfo()
    {
        
    }

    void LoadGameInfo()
    {
        
    }

    void AssembleMapData()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
