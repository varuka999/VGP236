using UnityEngine;

public class SequenceLoader : MonoBehaviour
{
    //[SerializeField] private DungeonManager _dungeonManagerScript = null;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject _dungeonManagerPrefab = null;
    [SerializeField] private GameObject _playerPrefab;
    // Enemies to spawn/EnemySpawner

    private void Awake()
    {
        if (_dungeonManagerPrefab != null)
        {
            _dungeonManagerPrefab.GetComponent<DungeonManager>().Initialize();
        }
        else
        {
            Debug.LogError("Missing: Dungeon Manager");
            //return;
        }

        if (_playerPrefab != null)
        {

            GameObject player = Instantiate(_playerPrefab);
            player.GetComponent<PlayerController>().Initialize();

            if (_enemySpawner != null)
            {

                _enemySpawner.Initialize(_dungeonManagerPrefab, player);
            }
            else
            {
                Debug.LogError("Missing: Enemy Spawner");
                return;
            }
        }
        else
        {
            Debug.LogError("Missing: Player Prefab");
            return;
        }
    }
}
