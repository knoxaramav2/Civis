using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Cell[][][] _matrix;

    //dimensions
    private int _width, _height, _depth;

    public Map(int width, int length, int height)
    {
        //initialize map memory
        _matrix = new Cell[width][][];
        for (var x = 0; x < width; ++x)
        {
            _matrix[x] = new Cell[length][];
            for (var y = 0; y < height; ++y)
                _matrix[x][y] = new Cell[height];
        }
    }
}

public class Cell
{
    public List<Entity> Occupants;

    private int _x, _y, _z;

    public Cell(int x, int y, int z)
    {
        _x = x;
        _y = y;
        _z = z;
    }
}