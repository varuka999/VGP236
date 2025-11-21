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
        int chaseC = dungeonManager.GetComponent<DungeonManager>().ExitRoom.CoordinateC;
        int chaseR = dungeonManager.GetComponent<DungeonManager>().ExitRoom.CoordinateR;
        GameObject chasingAI = Instantiate(_chasingAIPrefab, new Vector3(chaseC * 5, 1.5f, chaseR * 5), Quaternion.Euler(0, 0, 0));
        chasingAI.GetComponent<AIChaser>().Initialize(player.transform);

        // Territory AI/s
        int previousIndex = 0;
        for (int i = 0; i < 2; ++i)
        {
            int territorySpawn = dungeonManager.GetComponent<DungeonManager>().GetRandomSpawnIndex();

            if (territorySpawn != previousIndex)
            {
                int c = territorySpawn % 19;
                int r = territorySpawn / 19;

                GameObject territoryAI = Instantiate(_territoryAIPrefab, new Vector3(c * 5, 1.5f, r * 5), Quaternion.Euler(0, 0, 0));
                territoryAI.GetComponent<AITerritory>().Initialize(player.transform, territorySpawn);
            }
            else
            {
                --i;
            }
        }

        // Wandering AI
        int wandereSpawn = dungeonManager.GetComponent<DungeonManager>().GetRandomSpawnIndex();
        int wandererC = wandereSpawn % 19;
        int wandererR = wandereSpawn / 19;
        GameObject wanderingAI = Instantiate(_wanderingAIPrefab, new Vector3(wandererC * 5.1f, 1.5f, wandererR * 5.1f), Quaternion.Euler(0, 0, 0));
        wanderingAI.GetComponent<AIWanderer>().Initialize(dungeonManager.GetComponent<DungeonManager>().RoomIndexList);
    }
}
