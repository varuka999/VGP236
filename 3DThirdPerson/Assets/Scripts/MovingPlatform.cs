using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    [SerializeField] private Vector3 _endPosition = Vector3.zero;
    private float _moveDuration = 2.0f;
    private float _waitDuration = 1.0f;

    private void Awake()
    {
        _startPosition = transform.position;

        StartCoroutine(DoMovement());
    }

    IEnumerator DoMovement()
    {
        yield return null;

        WaitForSeconds moveWait = new WaitForSeconds(_moveDuration);
        WaitForSeconds waitWait = new WaitForSeconds(_waitDuration);

        while (true)
        {
            yield return waitWait;

            Tween moveTween = transform.DOMove(_endPosition, _moveDuration);
            moveTween.Play();
            yield return moveWait;

            moveTween.Kill();
            yield return waitWait;

            moveTween = transform.DOMove(_startPosition, _moveDuration);
            moveTween.Play();
            yield return moveWait;

            moveTween.Kill();
        }
    }
}


