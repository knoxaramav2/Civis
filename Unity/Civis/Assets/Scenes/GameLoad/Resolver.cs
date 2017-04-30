using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	    _map = _dataShuttle.GetComponent <Map>();
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
        _text.text = "Calculating Map";

        //generate info maps
        _session.TerrainMap = new Tile.Terrain[_session.MapWidth][];
        _session.HeightMap = new int[_session.MapWidth][];

        for (var i = 0; i < _session.MapWidth; ++i)
        {
            _session.TerrainMap[i] = new Tile.Terrain[_session.MapLength];
            _session.HeightMap[i] = new int[_session.MapLength];
        }

        _map.HeightMap = _session.HeightMap;

        var counter = 0.001f;

        for (var x = 0; x < _session.MapWidth; ++x)
            for (var y = 0; y < _session.MapLength; ++y)
            {
                float xpos = counter + (x/_session.MapWidth);
                float ypos = counter + (x / _session.MapLength);

                _session.HeightMap[x][y] = (int)((Mathf.PerlinNoise(xpos, xpos)) * (2f + _session.Amplitude))+1;         
                counter += .1f;
            }               

        for (var x = 0; x < _session.MapWidth; ++x)
            for (var y = 0; y < _session.MapLength; ++y)
            {
                var xpos = counter + (x / _session.MapWidth);
                var ypos = counter + (x / _session.MapLength);

                _session.TerrainMap[x][y] = (Tile.Terrain)((int)
                        Mathf.Ceil((Mathf.PerlinNoise(xpos, xpos) * 3.99f)));

                counter += .08f;
            }

        for (var i = 0; i < _session.Smoothing; ++i)
        {
            for (var x = 0; x < _session.MapWidth; ++x)
                for (var y = 0; y < _session.MapLength; ++y)
                {
                    var cells = _map.GetAdjacentCells(x, y);
                    float avg = cells.Aggregate<Cell, float>(0, (current, cell) => current + cell.Z);
                    avg += _map.GetColumnHeight(x, y);
                    avg /= cells.Count + 1;
                    _map.HeightMap[x][y] = (int)Mathf.Ceil(avg);
                }
        }
            
    }

    void LoadGameInfo()
    {
        
    }

    void AssembleMapData()
    {
        
    }
}
