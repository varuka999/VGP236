using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint1 = null;
    [SerializeField] private GameObject _obstaclePrefab = null;
    [SerializeField] private float _timerBase = 2.5f;
    private float _timerCap = 0.0f;
    private float _timer = 0.0f;

    [SerializeField] private float _minObstacleXScale = 0.0f;
    [SerializeField] private float _maxObstacleXScale = 0.0f;
    [SerializeField] private float _minObstacleYScale = 0.0f;
    [SerializeField] private float _maxObstacleYScale = 0.0f;
    [SerializeField] private float _minObstacleRotate = 0.0f;
    [SerializeField] private float _maxObstacleRotate = 0.0f;
    [SerializeField] private float _obstacleMoveSpeed = 0.0f;

    private void Awake()
    {
        RandomizeTimer();
    }

    private void Update()
    {
        if (_timer < _timerCap)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            GameObject obstacle = Instantiate(_obstaclePrefab, _spawnPoint1);
            obstacle.transform.position = _spawnPoint1.position;
            obstacle.GetComponent<MovingObstacle>().Initialize(_minObstacleXScale, _maxObstacleYScale, _minObstacleYScale, _maxObstacleXScale, _minObstacleRotate, _maxObstacleRotate, _obstacleMoveSpeed);

            RandomizeTimer();
            _timer = 0;
        }
    }

    private void RandomizeTimer()
    {
        _timerCap = (_timerBase - _obstacleMoveSpeed) * (Random.Range(0.9f, 1.0f));
    }
}
