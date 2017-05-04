using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resolver : MonoBehaviour
{
    private GameObject          _dataShuttle;
    private Session             _session;
    private Map                 _map;
    private Text                _text;
    private LoadInfoManifest    _manifest;

	// Use this for initialization
	void Start () {
	    _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
	    _session = _dataShuttle.GetComponent<Session>();
	    _map = _dataShuttle.AddComponent<Map>();
	    _text = GameObject.Find("WaitText").GetComponent<Text>();
	    _manifest = _dataShuttle.AddComponent<LoadInfoManifest>();

        _map.Init();

	    if (_session.IsNewGame)
	    {
	        var ng = new NewGame(_session, _map, _text, _manifest);
            
            ng.InitNewGame();  
	    }
	    else
	    {
	        _text.text = "Loading Game";
            LoadGameInfo();
	    }
	        
        AssembleMapData();

        Debug.Log("Switching to game map");
        SceneManager.LoadScene("Field");
	}


    private void LoadGameInfo()
    {
        
    }

    private void AssembleMapData()
    {
        
    }
}
