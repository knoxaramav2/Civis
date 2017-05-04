using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapLoader : MonoBehaviour
{
    private GameObject _dataShuttle;
    private GameObject _state;
    private Map _map;
    private Session _session;
    private TileFactory _tileFactory;
    private LoadInfoManifest _manifest;
    private BuildingManager _buildingManager;
    private UnitManager _unitManager;

	// Use this for initialization
	void Start ()
	{
        _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
        _state = GameObject.FindGameObjectWithTag("State");
	    _map = _dataShuttle.GetComponent<Map>();
	    _session = _dataShuttle.GetComponent<Session>();
	    _map.HeightMap = _session.HeightMap;
	    _buildingManager = _state.GetComponent<BuildingManager>();
	    _unitManager = _state.GetComponent<UnitManager>();

	    _manifest = _dataShuttle.AddComponent<LoadInfoManifest>();
        

        _tileFactory = GetComponent<TileFactory>();

	    Random.InitState(_session.Seed.GetHashCode());

        Tile.Init(_map.Width, _map.Length);

        CreateMapFromMeta();
        ReadManifest();
	}

    public void CreateMapFromMeta()
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
    }

    public void ReadManifest()
    {
        Order order = null;
        while ((order = _manifest.GetNextOrder()) != null)
        {
            switch (order.Cmd)
            {
                case Order.Instruction.Create:

                    break;
                case Order.Instruction.Focus:

                    break;
                case Order.Instruction.Move:
                    break;
                case Order.Instruction.Destroy:
                    break;
                case Order.Instruction.Modify:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
