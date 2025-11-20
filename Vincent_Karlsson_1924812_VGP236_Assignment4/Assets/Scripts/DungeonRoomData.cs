using System;
using UnityEngine;

[Serializable]
public class DungeonRoomData
{
    private int _index = 0;
    private int _coordinateC = 0;
    private int _coordinateR = 0;
    private bool _isExit = false;

    public bool _isRoom = false;

    private DungeonRoomData _northConnection = null;
    private DungeonRoomData _eastConnection = null;
    private DungeonRoomData _southConnection = null;
    private DungeonRoomData _westConnection = null;

    public int Index { get => _index; }
    public int CoordinateC { get => _coordinateC; }
    public int CoordinateR { get => _coordinateR; }
    public DungeonRoomData NorthConnection { get => _northConnection; }
    public DungeonRoomData EastConnection { get => _eastConnection; }
    public DungeonRoomData SouthConnection { get => _southConnection; }
    public DungeonRoomData WestConnection { get => _westConnection; }
    public bool IsExit { get => _isExit; }

    public DungeonRoomData(int index, int width)
    {
        _index = index;
        _coordinateC = index % width;
        _coordinateR = index / width;

        _isRoom = true;
    }

    public DungeonRoomData(DungeonRoomData connectingRoom, int direction, int index, int width)
    {
        _index = index;
        _coordinateC = index % width;
        _coordinateR = index / width;

        SetConnection(connectingRoom, direction);

        _isRoom = true;
    }

    // Redo connections to use array of DungeonRoomData
    public void SetConnection(DungeonRoomData connectingRoom, int direction)
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
