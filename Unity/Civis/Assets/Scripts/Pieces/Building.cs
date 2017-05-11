using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Entity
{
	// Use this for initialization
    void Start()
    {
        base.Start();
        Debug.Log("Building up in here");

        Menu.AddButton("Spawn", SpawnUnit);
        Menu.AddButton("Close", () => { Menu.Hide(); });
    }

    void SpawnUnit()
    {
        Debug.Log("Spawn Unit");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
