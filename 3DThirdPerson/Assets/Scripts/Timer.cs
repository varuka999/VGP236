using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText = null;
    private float _timer = 0.0f;
    private int _minutes = 0;
    private int _seconds = 0;
    private bool _isGameEnd = false;

    private void Update()
    {
        if (_isGameEnd == false)
        {
            _timer += Time.deltaTime;
            _minutes = Mathf.FloorToInt(_timer / 60.0f);
            _seconds = Mathf.FloorToInt(_timer % 60.0f);
            _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
        }
    }

    // Maybe could use events in the future?
    public void SetGameEnd()
    {
        _isGameEnd = true;
    }
}
