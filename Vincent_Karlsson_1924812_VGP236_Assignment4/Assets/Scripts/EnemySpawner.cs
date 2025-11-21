using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _chasingAIPrefab;
    [SerializeField] private GameObject _territoryAIPrefab;
    [SerializeField] private GameObject _wanderingAIPrefab;

    // Make this better later
    public void Initialize(GameObject dungeonManager, GameObject player)
    {
        //int index = dungeonManager.GetComponent<DungeonManager>().ExitRoom.Index;
        int c = dungeonManager.GetComponent<DungeonManager>().ExitRoom.CoordinateC;
        int r = dungeonManager.GetComponent<DungeonManager>().ExitRoom.CoordinateR;
        GameObject chasingAI = Instantiate(_chasingAIPrefab, new Vector3(c * 5, 1.5f, r * 5), Quaternion.Euler(0, 0, 0));
        chasingAI.GetComponent<AIChaser>().Initialize(player.transform);

        GameObject wanderingAI = Instantiate(_wanderingAIPrefab, new Vector3(c * 5.1f, 1.5f, r * 5.1f), Quaternion.Euler(0, 0, 0));
        wanderingAI.GetComponent<AIWanderer>().Initialize(dungeonManager.GetComponent<DungeonManager>().RoomIndexList);
    }
}
