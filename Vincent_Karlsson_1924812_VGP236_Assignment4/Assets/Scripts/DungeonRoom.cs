using UnityEngine;
using System.Collections.Generic;

public class DungeonRoom : MonoBehaviour
{
    private int _index = 0;
    private int _coordinateX = 0;
    private int _coordinateY = 0;
    private bool _isExit = false;

    private DungeonRoom _northConnection = null;
    private DungeonRoom _eastConnection = null;
    private DungeonRoom _southConnection = null;
    private DungeonRoom _westConnection = null;

    public int CoordinateX { get => _coordinateX; }
    public int CoordinateY { get => _coordinateY; }
    public DungeonRoom NorthConnection { get => _northConnection; }
    public DungeonRoom EastConnection { get => _eastConnection; }
    public DungeonRoom SouthConnection { get => _southConnection; }
    public DungeonRoom WestConnection { get => _westConnection; }

    // Index (point), Width for coordinates
    public DungeonRoom(int index, int width)
    {
        _index = index;
        _coordinateX = index % width;
        _coordinateY = index / width;
    }

    public DungeonRoom(DungeonRoom connectingRoom, int direction, int index, int width)
    {
        _index = index;
        _coordinateX = index % width;
        _coordinateY = index / width;

        SetConnection(connectingRoom, direction);
    }

    public void SetConnection(DungeonRoom connectingRoom, int direction)
    {
        switch (direction)
        {
            case 0:
                if (_northConnection == null)
                {
                    _northConnection = connectingRoom;
                }
                break;
            case 1:
                if (_eastConnection == null)
                {
                    _eastConnection = connectingRoom;
                }
                break;
            case 2:
                if (_southConnection == null)
                {
                    _southConnection = connectingRoom;
                }
                break;
            case 3:
                if (_westConnection == null)
                {
                    _westConnection = connectingRoom;
                }
                break;
            default:
                break;
        }
    }

    public void SetAsExitRoom()
    {
        _isExit = true;
    }
}
