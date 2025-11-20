using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _chasingAIPrefab;
    [SerializeField] private GameObject _territoryAIPrefab;
    [SerializeField] private GameObject _wanderingAIPrefab;

    // Make this better later
    public void Initialize(GameObject dungeonManagerScript)
    {
        int index = dungeonManagerScript.GetComponent<DungeonManager>().ExitRoom.Index;
        int c = index % dungeonManagerScript.GetComponent<DungeonManager>().ExitRoom.CoordinateC;
        int r = index / dungeonManagerScript.GetComponent<DungeonManager>().ExitRoom.CoordinateR;
        GameObject chasingAI = Instantiate(_chasingAIPrefab, new Vector3(c * 5, 1.5f, r * 5), Quaternion.Euler(0, 0, 0));
    }
}
