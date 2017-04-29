using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    public bool IsNewGame;

    //map meta
    public int MapWidth, MapLength, MapHeight;
    public int MapRscDensity;
    public int MapAi;
    public int MapAiDifficulty;
    public string Seed;

	// Use this for initialization
	void Start ()
	{
	    IsNewGame = false;
	}
}
