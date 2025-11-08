using UnityEngine;

public class VictoryPlatform : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _victoryTextObj;

    private void OnTriggerEnter(Collider other)
    {
        _timer.SetGameEnd();
        _victoryTextObj.SetActive(true);
    }
}
