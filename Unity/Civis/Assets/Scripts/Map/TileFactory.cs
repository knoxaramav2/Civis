using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileFactory : MonoBehaviour
{
    private static GameObject _tile;

    private static Material _grass;
    private static Material _dirt;
    private static Material _ice;
    private static Material _desert;

    void Start()
    {
        _tile = Resources.Load("Models/TilePref") as GameObject;

        _grass = Resources.Load(
            "Models/Materials/GrassMaterial",
            typeof(Material)) as Material;
        _dirt = Resources.Load(
            "Models/Materials/DirtTile",
            typeof(Material)) as Material;
        _ice = Resources.Load(
            "Models/Materials/IceMaterial",
            typeof(Material)) as Material;
        _desert = Resources.Load(
            "Models/Materials/SandTile",
            typeof(Material)) as Material;
    }

    public Tile BuildTile(int x, int y, int z, Tile.Terrain terrain)
    {
        var ret = Instantiate(_tile);
        var tile = ret.GetComponent<Tile>();

        tile.X = x;
        tile.Y = y;
        tile.Z = z;
        tile.Type = terrain;

        var material = _grass;

        switch (terrain)
        {
            case Tile.Terrain.Desert:
                material = _desert;
                break;
            case Tile.Terrain.Dirt:
                material = _dirt;
                break;
            case Tile.Terrain.Ice:
                material = _ice;
                break;
        }

        tile.MoveTo(x, y, z);

        tile.GetComponent<Renderer>().material = material;

        return tile;
    }
}