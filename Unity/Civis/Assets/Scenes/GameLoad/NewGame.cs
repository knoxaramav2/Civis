using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewGame
{
    private Session _session;
    private Map _map;
    private Text _text;
    private LoadInfoManifest _manifest;

    public NewGame(Session session, Map map, Text text, LoadInfoManifest manifest)
    {
        _session = session;
        _map = map;
        _text = text;
        _manifest = manifest;
    }

    public void InitNewGame()
    {
        _text.text = "Spawning Map...";
        GenerateNewMap();
        _text.text = "Spawning Resources...";
        GenerateNewResources();
        _text.text = "Spawning Players...";
        GenerateNewPlayers();
    }

    private void GenerateNewMap()
    {
        //generate info maps
        _session.TerrainMap = new Tile.Terrain[_session.MapWidth][];
        _session.HeightMap = new int[_session.MapWidth][];

        for (var i = 0; i < _session.MapWidth; ++i)
        {
            _session.TerrainMap[i] = new Tile.Terrain[_session.MapLength];
            _session.HeightMap[i] = new int[_session.MapLength];
        }

        _map.HeightMap = _session.HeightMap;

        var heightCounter = 0.001f;
        var textureCounter = 0.001f;

        for (var x = 0; x < _session.MapWidth; ++x)
        for (var y = 0; y < _session.MapLength; ++y)
        {
            var xpos = heightCounter + ((float)x / _session.MapWidth);
            var ypos = heightCounter + ((float)y / _session.MapLength);

            _session.TerrainMap[x][y] = (Tile.Terrain)((int)
                Mathf.Ceil((Mathf.PerlinNoise(xpos, ypos) * 3.99f)));

            xpos = textureCounter + ((float)x / _session.MapWidth);
            ypos = textureCounter + ((float)y / _session.MapLength);

            _session.HeightMap[x][y] = (int)((Mathf.PerlinNoise(xpos, ypos)) * (2f + _session.Amplitude)) + 1;

            heightCounter += _session.HeightComplexity;
            textureCounter += _session.TerrainComplexity;
        }

        for (var i = 0; i < _session.Smoothing; ++i)
        {
            for (var x = 0; x < _session.MapWidth; ++x)
            for (var y = 0; y < _session.MapLength; ++y)
            {
                var cells = _map.GetAdjacentCells(x, y);
                var avg = cells.Aggregate<Cell, float>(0, (current, cell) => current + cell.Z);
                avg += _map.GetColumnHeight(x, y);
                avg /= cells.Count + 1;
                _map.HeightMap[x][y] = (int)Mathf.Ceil(avg);
            }
        }
    }

    private void GenerateNewResources()
    {

    }

    private void GenerateNewPlayers()
    {
        Debug.Log("Initializing players");
        //add local player
        _session.Players.Add(
            new Player()
            {
                UserName = "Player",
                UserId = "",
                IsHost = true,
                Team = Race.Type.Cyborg,
            }
            );

        _session.Current = _session.Players[0];
        InitPlayerAssets(_session.Current);

        for (var i = 0; i < _session.MapAi; ++i)
        {
            _session.Players.Add(
                new Player()
                {
                    UserName = "Player " + i,
                    UserId = Random.Range(0, int.MaxValue).ToString(),
                    IsHost = true,
                    Team = Race.Type.Cyborg,
                }
            );

            InitPlayerAssets(_session.Players[i + 1]);


        }
    }

    private void InitPlayerAssets(Player p)
    {
        Debug.Log("Creating new player manifest");
        //create user manifest
        var locOrder = new Order()
        {
            Cmd = Order.Instruction.Create,
            Type = Order.TargetType.Building,
            OwnerId = p.UserId,
            TargetId = Random.Range(0, int.MaxValue).ToString()
        };

        locOrder.AddAttribute(
            Order.Keys.Location, 
            string.Format("{0},{1}", 
            Random.Range(0, _map.Width), 
            Random.Range(0, _map.Length)));

        var bId = Random.Range(0, int.MaxValue);

        locOrder.AddAttribute(
            Order.Keys.Type,
            string.Format("{0},{1}", "Town", bId));

        _manifest.AddOrder(locOrder);

        if (!p.IsHost) return;

        var camOrder = new Order()
        {
            Cmd = Order.Instruction.Focus,
            Type = Order.TargetType.Camera,
            OwnerId = p.UserId,
            TargetId = ""
        };

        camOrder.AddAttribute(Order.Keys.Target, bId.ToString());

        _manifest.AddOrder(camOrder);

    }
}
