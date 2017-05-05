using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.System;
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

	    _manifest = _dataShuttle.GetComponent<LoadInfoManifest>();
        

        _tileFactory = GetComponent<TileFactory>();

	    Random.InitState(_session.Seed.GetHashCode());

        Tile.Init(_map.Width, _map.Length);

        CreateMapFromMeta();
        ReadManifest();
	}

    public void CreateMapFromMeta()
    {
        //generate base map
        Debug.Log("Loading tiles");
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
                }
            }
        }
    }

    public void ReadManifest()
    {
        Debug.Log("Reading manifests orders: " + _manifest.Count());
        Order order = null;
        while ((order = _manifest.GetNextOrder()) != null)
        {
            Debug.Log(order.Cmd);
            switch (order.Cmd)
            {
                case Order.Instruction.Create:
                    Create(order);
                    break;
                case Order.Instruction.Focus:
                    Focus(order);
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

    public void Create(Order order)
    {
        switch (order.Type)
        {
            case Order.TargetType.Building:
                var loc = order.Attributes.First(k => k.Key == Order.Keys.Location);

                var coord = loc.Value.Split(',');

                int x, y;
                int.TryParse(coord[0], out x);
                int.TryParse(coord[1], out y);

                var cell = _map.GetTopCell(x, y);
                Debug.Log(string.Format("Selected at {0} {1} {2}", cell.X, cell.Y, cell.Z));

                _buildingManager.CreateBuilding(
                    _session.GetPlayerById(order.OwnerId),
                    "",
                    cell
                    
                );

                break;
        }
    }

    public void Focus(Order order)
    {
        foreach (var e in _session.Current.Pieces)
        {
            if (!(e is Building)) continue;

            CameraControl.ZoomTo();
        }
    }
}
