using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _chasingAIPrefab;
    [SerializeField] private GameObject _territoryAIPrefab;
    [SerializeField] private GameObject _wanderingAIPrefab;

    // Maybe make this better later?
    public void Initialize(GameObject dungeonManager, GameObject player)
    {
        /// Chasing AI
        DungeonRoomData exitRoom = dungeonManager.GetComponent<DungeonManager>().ExitRoom;
        int index = exitRoom.Index;

        GameObject chasingAI = Instantiate(_chasingAIPrefab, new Vector3(exitRoom.CoordinateC * 5, 1.5f, exitRoom.CoordinateR * 5), Quaternion.Euler(0, 0, 0));
        chasingAI.GetComponent<AIChaser>().Initialize(player.transform, index);

        // Territory AI/s
        int previousIndex = 0;
        for (int i = 0; i < 2; ++i)
        {
            int territorySpawn = dungeonManager.GetComponent<DungeonManager>().GetRandomSpawnIndex();

            if (territorySpawn != previousIndex) // Technically won't work properly if more than 2 territory enemies are spawned
            {
                int c = territorySpawn % 19; // bad magic number :(, relies on the map dimensions not changing
                int r = territorySpawn / 19;

                GameObject territoryAI = Instantiate(_territoryAIPrefab, new Vector3(c * 5, 1.5f, r * 5), Quaternion.Euler(0, 0, 0));
                territoryAI.GetComponent<AITerritory>().Initialize(player.transform, territorySpawn);

                previousIndex = territorySpawn;
            }
            else
            {
                --i;
            }
        }

        // Wandering AI
        int wandererSpawn = dungeonManager.GetComponent<DungeonManager>().GetRandomSpawnIndex();
        int wandererC = wandererSpawn % 19;
        int wandererR = wandererSpawn / 19;
        GameObject wanderingAI = Instantiate(_wanderingAIPrefab, new Vector3(wandererC * 5.1f, 1.5f, wandererR * 5.1f), Quaternion.Euler(0, 0, 0));
        wanderingAI.GetComponent<AIWanderer>().Initialize(dungeonManager.GetComponent<DungeonManager>().RoomIndexList);
    }
}
