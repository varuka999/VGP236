using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager _instance = null;
    private Transform _currentCheckPoint = null;

    public static CheckpointManager Instance { get =>  _instance; }
    public Transform CurrentCheckPoint { get => _currentCheckPoint; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetNewCheckpoint(Transform transform)
    {
        _currentCheckPoint = transform;
    }
}
