using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
