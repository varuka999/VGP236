using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    private List<DungeonRoom> _dungeon = new List<DungeonRoom>();
    private DungeonRoom[] _dungeonArray;
    private DungeonRoom _exitRoom;

    [SerializeField] private int _widthBase = 5;
    [SerializeField] private int _heightBase = 5;

    private int _width = 0;

    private void Awake()
    {
        _dungeon.Clear();
        DungeonGenerationTest();
    }

    public void DungeonGenerationTest()
    {
        int width = _widthBase + Random.Range(0, 5);
        int height = _heightBase + Random.Range(0, 5);
        int dimension = width * height;
        int centerX = width / 2;
        int centerY = height / 2;
        int centerIndex = centerY * width + centerX;
        int numberOfRoomsToGenerate = (dimension / 3) + Random.Range(0, dimension / 3);
        _width = width;

        _dungeon = Enumerable.Repeat<DungeonRoom>(null, dimension).ToList(); // Resizes the List to be X number of null, where X is equal to dimension
        List<int> roomIndexList = new List<int>(); // Keeps tarck of the index of each room that has been created

        int currentRoomIndex = centerIndex;
        int maxBranchLength = width + Random.Range(0, height / 2);
        int currentBranchLength = 0;
        int failedToCreateRoomCounter = 0;
        int resetToCenterCounter = 0;

        for (int i = 0; i < numberOfRoomsToGenerate; ++i)
        {
            // If the generation process has been forced to reset too many times before the desired room amount, end the process early
            if (resetToCenterCounter >= 0)
            {
                break;
            }

            // First room is always created in the center of the map
            if (_dungeon[currentRoomIndex] == null)
            {
                _dungeon[currentRoomIndex] = new DungeonRoom(currentRoomIndex, width);
                roomIndexList.Add(currentRoomIndex);
            }
            else
            {
                int nextRoomIndex = 0;
                int direction = Random.Range(0, 4); // 0-3, North = 0, East = 1, South = 2, West = 3
                int oppositeDirection = (direction + 2) % 4; // Remainder always returns opposide direction (ex, 3 + 2 = 5, 5 % 4 = 1, remainder 1; Direction = 3 = West, Opposite = 1 = East)
                int safteCounter = 0;

                // Creates a new room based on the direction if there is empty space or is not out of boundss
                // If a new room can't be created, move the current room to the existing room
                while (true)
                {
                    // Continues until the next index based on current index + direction is in bounds (can only be out of bounds twice)
                    while (IsNextRoomInBounds(currentRoomIndex, direction, height) == false)
                    {
                        direction = ReturnNewDirection(direction, 1); // Rotates the direction clockwise to ensure all directions are checked at most once
                    }
                    // On exit, the next room is verified to be in bounds

                    oppositeDirection = ReturnNewDirection(direction, 2);

                    // North
                    if (direction == 0)
                    {
                        nextRoomIndex = currentRoomIndex - width;
                    }
                    // East
                    else if (direction == 1)
                    {
                        nextRoomIndex = currentRoomIndex + 1;
                    }
                    // South
                    else if (direction == 2)
                    {
                        nextRoomIndex = currentRoomIndex + width;
                    }
                    // West
                    else if (direction == 3)
                    {
                        nextRoomIndex = currentRoomIndex - 1;
                    }

                    // Creates a new room if the index space if empty
                    if (_dungeon[nextRoomIndex] == null)
                    {
                        _dungeon[nextRoomIndex] = new DungeonRoom(_dungeon[currentRoomIndex], oppositeDirection, nextRoomIndex, width);
                        _dungeon[currentRoomIndex].SetConnection(_dungeon[nextRoomIndex], direction); // Need to also set the connection from the previous room to the new room (connections are 2 way)
                        roomIndexList.Add(nextRoomIndex);

                        ++currentBranchLength;
                        failedToCreateRoomCounter = 0;

                        // Check neighbouring rooms and make any new available connections
                        for (int d = 0; d < 4; ++i)
                        {
                            if (IsNextRoomInBounds(nextRoomIndex, d, height) == true)
                            {
                                int adjacentIndex = ReturnAdjacentIndex(nextRoomIndex, d);

                                if (_dungeon[adjacentIndex] != null)
                                {
                                    _dungeon[nextRoomIndex].SetConnection(_dungeon[adjacentIndex], d);
                                    _dungeon[adjacentIndex].SetConnection(_dungeon[nextRoomIndex], ReturnNewDirection(d, 2));
                                }
                            }
                        }
                    }
                    // If the next room index is already occupied by an existing room
                    else
                    {
                        // --i makes sure the process creates the desired number of rooms
                        --i;
                        ++failedToCreateRoomCounter;
                    }

                    // Controls an aspect of room generation by resetting to the center after a particular number of rooms has been created
                    if (currentBranchLength > maxBranchLength)
                    {
                        currentBranchLength = 0;
                        currentRoomIndex = centerIndex;
                        break;
                    }

                    // If the randomization of the room creation has a run of bad RNG it might be stuck in a circle/block of rooms, reset to center
                    if (failedToCreateRoomCounter >= 10)
                    {
                        failedToCreateRoomCounter = 0;
                        ++resetToCenterCounter;

                        currentRoomIndex = centerIndex;
                        //currentRoomIndex = roomIndexList[Random.Range(0, roomIndexList.Count)]; // Alternate generation, resets to a random room that has already been created instead of center
                        break;
                    }

                    currentRoomIndex = nextRoomIndex;

                    break;
                }
            }
        }

        int startingRoomIndex = roomIndexList[Random.Range(0, roomIndexList.Count)];
        int exitRoomIndex = roomIndexList[Random.Range(0, roomIndexList.Count)];
        int safetyCounter = 0;

        // Attempts to have the exit be at least a certain distance from the starting room (safety counter to avoid bad RNG causing lag spike)
        while (Mathf.Abs(_dungeon[exitRoomIndex].CoordinateX - _dungeon[startingRoomIndex].CoordinateX)
            + Mathf.Abs(_dungeon[exitRoomIndex].CoordinateY - _dungeon[startingRoomIndex].CoordinateY) < (width / 2)
            || safetyCounter < 50)
        {
            exitRoomIndex = roomIndexList[Random.Range(0, roomIndexList.Count)];
            ++safetyCounter;
        }

        // Assigns starting and exit room
        // UpdateCurrentRoom (tells player where to spawn?)
        _exitRoom = _dungeon[exitRoomIndex];
        _exitRoom.SetAsExitRoom();
    }

    // Adjustment refers to how many clockwise direction changes (1 would be North -> East, whereas 2 would be North -> South)
    private int ReturnNewDirection(int direction, int adjustmentAmount)
    {
        return (direction + adjustmentAmount) % 4;
    }

    // If the projected index in the desired direction is out of bounds of the simulated 2D 'array', then return false
    private bool IsNextRoomInBounds(int currentRoomIndex, int direction, int height)
    {
        // North
        if (direction == 0 && currentRoomIndex < _width) // Current room is in the top row
        {
            return false;
        }
        // East
        if (direction == 1 && currentRoomIndex % _width == _width - 1) // Current room is in the right most column
        {
            return false;
        }
        // South
        if (direction == 2 && currentRoomIndex >= (_width * (height - 1))) // Current room is in the bottom row
        {
            return false;
        }
        // West
        if (direction == 3 && currentRoomIndex % _width == 0) // Current room is in the left most column
        {
            return false;
        }

        return true;
    }

    private int ReturnAdjacentIndex(int currentRoomIndex, int direction)
    {
        switch (direction)
        {
            case 0:
                return currentRoomIndex - _width; // North
            case 1:
                return currentRoomIndex + 1;      // East
            case 2:
                return currentRoomIndex + _width; // South
            case 3:
                return currentRoomIndex - 1;      // West
            default:
                return -1; // Invalid
        }
    }

    private bool ReturnIfRoomIsAdjacent(DungeonRoom adjacentRoom, DungeonRoom currentRoom)
    {
        if (adjacentRoom.NorthConnection == currentRoom)
        {
            return true;
        }
        if (adjacentRoom.EastConnection == currentRoom)
        {
            return true;
        }
        if (adjacentRoom.SouthConnection == currentRoom)
        {
            return true;
        }
        if (adjacentRoom.WestConnection == currentRoom)
        {
            return true;
        }

        return false;
    }
}
