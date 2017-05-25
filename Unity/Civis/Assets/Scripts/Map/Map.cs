using System;
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
        _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
        _session = _dataShuttle.GetComponent<Session>();

        Width = _session.MapWidth;
        Height = _session.MapHeight;
        Length = _session.MapLength;

        Tile.Init(Width, Height);

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
    }

    public void AddTile(Tile t)
    {
        _matrix[t.X][t.Y][t.Z].Target = t;
    }

    public int GetColumnHeight(int x, int y)
    {
        return IsOutOfBounds(x,y) ?
            0 :
            HeightMap[x][y];
    }

    public Tile GetTopTile(int x, int y)
    {
        return _matrix[x][y][GetColumnHeight(x, y) - 1].Target;
    }

    public Cell GetTopCell(int x, int y)
    {
        return _matrix[x][y][GetColumnHeight(x, y)];
    }

    public int GetHeightDiff(int x1, int y1, int x2, int y2)
    {
        var h1 = GetColumnHeight(x1, y1);
        var h2 = GetColumnHeight(x2, y2);
        return h2 - h1;
    }

    public List <Cell> GetAdjacentCells(Tile tile, int rad=1, bool ele=false)
    {
        return GetAdjacentCells(tile.X, tile.Y, rad);
    }

    public List<Cell> GetAdjacentCells(int x, int y, int rad=1, bool ele=false)
    {
        var list = new List<Cell>();

        var origin = GetTopCell(x, y);
        var current = origin;

        var prvEdge = Tile.Edge.TopLeft;

        //append if new level, transfer if current

        for (var n = 0; n < rad; ++n)
        {
            //transfer every (n+3)(n>0)
            //rotate every n+1
            var index = 0;
            do
            {
                var target = GetAdjacentCell(current.X, current.Y, prvEdge);
                if (target != null) list.Add(target);

                //rotate edge
                if (index % (n + 1) == 0)
                {
                    prvEdge = GetRotatedEdge(prvEdge);
                }

                if ((index % (n + 3)) == 0 && (n > 0))
                {

                    current = GetAdjacentCell(current.X, current.Y, GetRotatedEdge(prvEdge));
                }

                ++index;
            } while (current != origin || prvEdge != Tile.Edge.TopLeft);

            origin = GetAdjacentCell(origin.X, origin.Y, Tile.Edge.TopLeft);

        }

        return list;
    }

    public Cell GetAdjacentCell(int x, int y, Tile.Edge edge)
    {
        var coord = Tile.GetAdjacentCoord(x, y, edge);
        if (coord == null) return null;
        return IsOutOfBounds(coord[0], coord[1])
            ? null 
            : GetTopCell(coord[0], coord[1]);
    }

    public float GetAverageHeight(int x, int y)
    {
        var cells = GetAdjacentCells(x, y);

        var avg = cells.Aggregate<Cell, float>(0, (current, cell) => current + cell.Z);

        return avg / cells.Count;
    }

    private bool IsOutOfBounds(int x, int y)
    {
        return (x<0 || y<0 || x > Width || y > Length);
    }

    private Tile.Edge GetRotatedEdge(Tile.Edge prvEdge)
    {
        switch (prvEdge)
        {
            case Tile.Edge.TopLeft: prvEdge = Tile.Edge.TopRight; break;
            case Tile.Edge.TopRight: prvEdge = Tile.Edge.Right; break;
            case Tile.Edge.Right: prvEdge = Tile.Edge.BottomRight; break;
            case Tile.Edge.BottomRight: prvEdge = Tile.Edge.BottomLeft; break;
            case Tile.Edge.BottomLeft: prvEdge = Tile.Edge.Left; break;
            case Tile.Edge.Left: prvEdge = Tile.Edge.TopLeft; break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return prvEdge;
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