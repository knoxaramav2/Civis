using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private static int _columns, _rows;

    public static float XOffset = 1.73205f;
    public static float YOffset = 1.5f;
    public static float ZOffset = 1f;

    public static void Init(int col, int row)
    {
        _columns = col;
        _rows = row;
    }
    
    public void MoveTo(int x, int y, int z)
    {
        this.gameObject.transform.position = new Vector3(
            (x * XOffset + ((y % 2)*(XOffset/2))) - _columns,
            z * ZOffset,
            (y * YOffset) - (_rows * YOffset) / 2);
    }

    public static int[] GetAdjacentCoord(int x, int y, Edge edge)
    {
        var coord = new int[3];
        coord[0] = -1;//return null if this is not changed

        switch (edge)
        {
            case Edge.TopLeft:
                if ((y % 2 == 0) && (x > 0) && (y < _rows - 1))
                {
                    coord[0] = x - 1;
                    coord[1] = y + 1;
                }
                else if ((y % 2 == 1) && (y < _rows - 1))
                {
                    coord[0] = x;
                    coord[1] = y + 1;
                }
                break;
            case Edge.Left:
                if (x > 0)
                {
                    coord[0] = x - 1;
                    coord[1] = y;
                }
                break;
            case Edge.BottomLeft:
                if ((y % 2 == 0) && (x > 0) && (y > 0))
                {
                    coord[0] = x - 1;
                    coord[1] = y - 1;
                }
                else if ((y % 2 == 1) && (y > 0))
                {
                    coord[0] = x;
                    coord[1] = y - 1;
                }
                break;
            case Edge.TopRight:
                if ((y % 2 == 0) && (y < _rows - 1))
                {
                    coord[0] = x;
                    coord[1] = y + 1;
                }
                else if ((y % 2 == 1) && (x < _columns - 1) && (y < _rows - 1))
                {
                    coord[0] = x + 1;
                    coord[1] = y + 1;
                }
                break;
            case Edge.Right:
                if (x < _columns - 1)
                {
                    coord[0] = x + 1;
                    coord[1] = y;
                }
                break;
            case Edge.BottomRight:
                if ((y % 2 == 0) && (y > 0))
                {
                    coord[0] = x;
                    coord[1] = y - 1;
                }
                else if ((y % 2 == 1) && (x < _columns - 1) && (y > 0))
                {
                    coord[0] = x + 1;
                    coord[1] = y - 1;
                }
                break;
        }

        return coord[0] == -1 ? null : coord;
    }

    public Vector3 GetSurfaceCoord()
    {
        return new Vector3((X * XOffset + (Y % 2)) - _columns, (Z + 1) * ZOffset, (Y * YOffset) - (_rows * YOffset) / 2);
    }

    public enum Terrain
    {
        
        Desert,
        Dirt,
        Grass,
        Ice
    }

    public enum Edge
    {
        TopLeft,
        Left,
        BottomLeft,

        TopRight,
        Right,
        BottomRight
    }

    public int X, Y, Z;
    public Terrain Type;
}
