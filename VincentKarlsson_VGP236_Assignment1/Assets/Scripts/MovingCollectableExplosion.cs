using System.Collections;
using UnityEngine;

public class MovingCollectableExplosion : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ExplosionCoroutine());
    }

    public IEnumerator ExplosionCoroutine()
    {
        yield return new WaitForSeconds(0.3f);

        this.gameObject.SetActive(false);
    }
}
