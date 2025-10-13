using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;

    public static ScoreManager Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
