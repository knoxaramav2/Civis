using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject _dataShuttle;
    private Session _session;
    private Cell[][][] _matrix;

    public int[][] HeightMap;

    //dimensions
    public int Width, Length, Height;

    public void Init()
    {
        Debug.Log("asdasdasdasd");

        _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
        _session = _dataShuttle.GetComponent<Session>();

        Width = _session.MapWidth;
        Height = _session.MapHeight;
        Length = _session.MapLength; 

        //initialize map memory
        _matrix = new Cell[Width][][];
        for (var x = 0; x < Width; ++x)
        {
            _matrix[x] = new Cell[Length][];
            for (var y = 0; y < Length; ++y)
            {
                _matrix[x][y] = new Cell[Height];
                for (var z = 0; z < Height; ++z)
                {
                    _matrix[x][y][z] = new Cell(x,y,z);
                }
            }
        }

        Debug.Log(_matrix);
    }

    public void AddTile(Tile t)
    {
        _matrix[t.X][t.Y][1].Target = t;
    }

    public int GetColumnHeight(int x, int y)
    {
        Debug.Log(HeightMap);
        return HeightMap[x][y];
    }

    public Tile GetTopTile(int x, int y)
    {
        return _matrix[x][y][GetColumnHeight(x, y) - 1].Target;
    }

    public Cell GetTopCell(int x, int y)
    {
        Debug.Log(_matrix);
        return _matrix[x][y][GetColumnHeight(x, y) - 1];
    }

    public List <Cell> GetAdjacentCells(Tile tile)
    {
        return GetAdjacentCells(tile.X, tile.Y);
    }

    public List<Cell> GetAdjacentCells(int x, int y)
    {
        var list = new List<Cell>();

        var ctl = Tile.GetAdjacentCoord(x, y, Tile.Edge.TopLeft);
        var ctr = Tile.GetAdjacentCoord(x, y, Tile.Edge.TopRight);
        var cl = Tile.GetAdjacentCoord(x, y, Tile.Edge.Left);
        var cr = Tile.GetAdjacentCoord(x, y, Tile.Edge.Right);
        var cbl = Tile.GetAdjacentCoord(x, y, Tile.Edge.BottomLeft);
        var cbr = Tile.GetAdjacentCoord(x, y, Tile.Edge.BottomRight);

        if (ctl != null) list.Add(GetTopCell(ctl[0], ctl[1]));
        if (ctr != null) list.Add(GetTopCell(ctr[0], ctr[1]));
        if (cl != null) list.Add(GetTopCell(cl[0], cl[1]));
        if (cr != null) list.Add(GetTopCell(cr[0], cr[1]));
        if (cbl != null) list.Add(GetTopCell(cbl[0], cbl[1]));
        if (cbr != null) list.Add(GetTopCell(cbr[0], cbr[1]));

        return list;
    }

    public float GetAverageHeight(int x, int y)
    {
        var cells = GetAdjacentCells(x, y);

        var avg = cells.Aggregate<Cell, float>(0, (current, cell) => current + cell.Z);

        return avg / cells.Count;
    }
}

public class Cell
{
    public Tile Target;

    public int X, Y, Z;

    public Cell(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;

        Target = null;
    }
}