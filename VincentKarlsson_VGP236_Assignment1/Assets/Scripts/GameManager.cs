using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance = null;
    [SerializeField] private GameObject _finalScoreScreen = null;

    public GameManager Instance { get => _instance; }

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
}
