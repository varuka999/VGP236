using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null;
    [SerializeField] private TMP_Text _scoreText = null;
    [SerializeField] private TMP_Text _counterText1 = null;
    [SerializeField] private TMP_Text _counterText3 = null;
    [SerializeField] private TMP_Text _counterText10 = null;
    private int _score = 0;
    private int _counter1 = 0;
    private int _counter3 = 0;
    private int _counter10 = 0;

    public static ScoreManager Instance { get { return _instance; } }

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

    public void UpdateScore(int score)
    {
        _score += score;
        UpdateScoreText();

        switch (score)
        {
            case 1:
                _counter1++;
                _counterText1.text = _counter1.ToString();
                break;
            case 3:
                _counter3++;
                _counterText3.text = _counter3.ToString();
                break;
            case 10:
                _counter10++;
                _counterText10.text = _counter10.ToString();
                break;
            default:
                break;
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Descruction Score: " + _score.ToString();
    }
}
