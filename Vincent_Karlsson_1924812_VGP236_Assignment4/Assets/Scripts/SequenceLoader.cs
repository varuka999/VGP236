using UnityEngine;

public class SequenceLoader : MonoBehaviour
{
    [SerializeField] private TEMP_PlayerController _playerControllerScript = null;
    [SerializeField] private PlayerDestination _playerDestinationScript = null;
    [SerializeField] private DungeonGeneration _dungeonGenerationScript = null;

    private void Awake()
    {
        if (_dungeonGenerationScript != null)
        {
            _dungeonGenerationScript.Initialize();
        }
        else
        {
            Debug.LogError("Missing: Dungeon Generation");
            return;
        }

        if (_playerControllerScript != null)
        {
            _playerControllerScript.Initialize();
        }
        else
        {
            Debug.LogError("Missing: Player Controller");
            return;
        }

        if (_playerDestinationScript != null)
        {
            _playerDestinationScript.Initialize(_playerControllerScript);
        }
        else
        {
            Debug.LogError("Missing: Player Destination");
        }
    }
}
