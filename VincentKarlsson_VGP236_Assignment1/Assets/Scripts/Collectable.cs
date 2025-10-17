using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] protected GameObject _collectableCollision = null;
    [SerializeField] protected float _respawnTime = 0.0f;
    protected float _respawnTimer = 0.0f;

    protected void Update()
    {
        CollectableRespawn();
    }

    protected virtual void CollectableRespawn()
    {
        if (_collectableCollision.gameObject.activeSelf == false)
        {
            _respawnTimer += Time.deltaTime;

            if (_respawnTimer > _respawnTime)
            {
                _collectableCollision.gameObject.SetActive(true);
                _respawnTimer = 0.0f;
            }
        }
    }
}
