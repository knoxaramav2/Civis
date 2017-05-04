using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    private GameObject _dataShuttle;
    private Map _map;
    private Session _session;
    private TileFactory _tileFactory;

	// Use this for initialization
	void Start ()
	{
        _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
	    _map = _dataShuttle.GetComponent<Map>();
	    _session = _dataShuttle.GetComponent<Session>();
	    _map.HeightMap = _session.HeightMap;

        _tileFactory = GetComponent<TileFactory>();

	    Random.InitState(_session.Seed.GetHashCode());

        Tile.Init(_map.Width, _map.Length);

        LoadFromMeta();
	}

    public void LoadFromMeta()
    {
        //generate base map
        for (var x = 0; x < _map.Width; ++x)
        {
            for (var y = 0; y < _map.Length; ++y)
            {
                //build only needed range
                var adjList = _map.GetAdjacentCells(x, y);

                var max = _session.HeightMap[x][y];
                var min = adjList.Select(t => t.Z).Concat(new[] {max}).Min();

                for (var z = min; z <= max; ++z)
                {
                    var tile = _tileFactory.BuildTile(
                        x, y, z,
                        _session.TerrainMap[x][y]);
                    _map.AddTile(tile);
                }
            }
        }

        //read manifest
    }
}
