using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText = null;
    private float _timer = 0.0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        _timerText.text = _timer.ToString();
    }
}
