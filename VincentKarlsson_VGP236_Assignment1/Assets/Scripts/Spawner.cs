using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _ballSpawnerParent;

    private void Update()
    {
        if (_ball != null && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(_ball, _ballSpawnerParent);
            ball.transform.position = transform.position;
        }
    }
}
