using UnityEngine;

public class SequenceLoader : MonoBehaviour
{
    [SerializeField] private PlayerController _playerControllerScript = null;
    [SerializeField] private PlayerDestination _playerDestinationScript = null;

    private void Awake()
    {
        if (_playerControllerScript != null)
        {
            _playerControllerScript.Initialize();
        }
        else
        {
            Debug.Log("Missing: Player Controller");
        }
        if (_playerDestinationScript != null)
        {
            _playerDestinationScript.Initialize(_playerControllerScript);
        }
        else
        {
            Debug.Log("Missing: Player Destination");
        }
    }
}
