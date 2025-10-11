using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    [SerializeField] private GameObject mushroomPrefab = null;
    [SerializeField] private GameObject bombPrefab = null;
    [SerializeField] private float spawnDelay = 2.0f;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private RangeInt spawnAmount = new RangeInt(1,3);

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}
