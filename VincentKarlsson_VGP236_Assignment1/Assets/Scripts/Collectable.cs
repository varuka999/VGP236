using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject _collectableCollision = null;
    [SerializeField] private float _respawnTime = 0.0f;
    private float _respawnTimer = 0.0f;

    private void Update()
    {
        if (_collectableCollision.gameObject.activeSelf == false)
        {
            _respawnTimer += Time.deltaTime;

            if (_respawnTimer > _respawnTime )
            {
                _collectableCollision.gameObject.SetActive(true);
                _respawnTimer = 0.0f;
            }
        }
    }
}
