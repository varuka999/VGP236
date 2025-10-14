using System.Collections;
using UnityEngine;

public class MovingCollectable : Collectable
{
    [SerializeField] private GameObject _indicator = null;
    private bool _isIndicatorActive = false;

    protected override void CollectableRespawn()
    {
        if (_collectableCollision.gameObject.activeSelf == false && _isIndicatorActive == false)
        {
            _respawnTimer += Time.deltaTime;

            if (_respawnTimer > _respawnTime)
            {
                _isIndicatorActive = true;
                StartCoroutine(IndicatorCoroutine());
            }
        }
    }

    private IEnumerator IndicatorCoroutine()
    {
        int spawnID = Random.Range(0, 4);
        Vector3 indicatorPosition = new Vector3(0, 0, 0);
        int direction = 1;

        switch (spawnID)
        {
            case 0:
                indicatorPosition = new Vector3(3, 2, 0);
                direction = -1;
                break;
            case 1:
                indicatorPosition = new Vector3(3, 1, 0);
                direction = -1;
                break;
            case 2:
                indicatorPosition = new Vector3(-3, 2, 0);
                break;
            case 3:
                indicatorPosition = new Vector3(-3, 1, 0);
                break;
            default:
                break;
        }

        _indicator.gameObject.transform.position = indicatorPosition;
        _indicator.gameObject.transform.localScale = new Vector3(_indicator.gameObject.transform.localScale.x, Mathf.Abs(_indicator.gameObject.transform.localScale.y) * direction, _indicator.gameObject.transform.localScale.z);

        for (int i = 0; i < 5; ++i)
        {
            _indicator.SetActive(true);
            yield return new WaitForSeconds(0.12f);
            _indicator.SetActive(false);
            yield return new WaitForSeconds(0.12f);
        }

        _collectableCollision.gameObject.transform.position = new Vector3((Mathf.Abs(indicatorPosition.x) + 2) * -direction, indicatorPosition.y, indicatorPosition.z);
        _collectableCollision.gameObject.transform.localScale = new Vector3(_collectableCollision.gameObject.transform.localScale.x, Mathf.Abs(_collectableCollision.gameObject.transform.localScale.y) * direction, Mathf.Abs(_collectableCollision.gameObject.transform.localScale.z) * direction);
        _collectableCollision.gameObject.SetActive(true);

        _respawnTimer = 0.0f;
        _isIndicatorActive = false;
    }
}
