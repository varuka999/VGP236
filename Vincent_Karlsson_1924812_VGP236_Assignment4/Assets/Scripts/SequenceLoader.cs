using UnityEngine;

public class SequenceLoader : MonoBehaviour
{
    [SerializeField] private GameObject _dungeonManagerPrefab = null;
    [SerializeField] private GameObject _enemySpawnerPrefab = null;
    [SerializeField] private GameObject _playerPrefab = null;

    private void Awake()
    {
        if (_dungeonManagerPrefab != null)
        {
            _dungeonManagerPrefab = Instantiate(_dungeonManagerPrefab);
            _dungeonManagerPrefab.GetComponent<DungeonManager>().Initialize();
        }
        else
        {
            Debug.LogError("Missing: Dungeon Manager");
            return;
        }

        if (_playerPrefab != null)
        {
            int spawnIndexPoint = _dungeonManagerPrefab.GetComponent<DungeonManager>().StartRoom.Index;
            int spawnC = spawnIndexPoint % 19;
            int spawnR = spawnIndexPoint / 19;

            GameObject player = Instantiate(_playerPrefab, new Vector3(spawnC * 5, 1.5f, spawnR * 5), Quaternion.Euler(0, 0, 0));
            player.GetComponent<PlayerController>().Initialize();

            if (_enemySpawnerPrefab != null)
            {

                _enemySpawnerPrefab.GetComponent<EnemySpawner>().Initialize(_dungeonManagerPrefab, player);
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
