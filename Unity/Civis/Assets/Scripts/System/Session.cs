using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public float Amplitude;
    public float Smoothing;

    public float HeightComplexity;
    public float TerrainComplexity;

    public Tile.Terrain[][] TerrainMap;
    public int[][] HeightMap;

    //Game state
    public List<Player> Players;

	// Use this for initialization
	void Start ()
	{
        Players = new List<Player>();

	    HeightComplexity = 0.055f;
	    TerrainComplexity = 0.055f;

	    IsNewGame = false;
	}

    public Player GetPlayerById(string id)
    {
        return Players.FirstOrDefault(p => p.UserId == id);
    }
}
