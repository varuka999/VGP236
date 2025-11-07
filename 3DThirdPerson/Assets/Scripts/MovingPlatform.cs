using System.Collections;
using Unity.VisualScripting;
using UnityEngine;



public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    [SerializeField] private Transform _endTransform = null;
    private bool goToEnd = true;
    private float moveTime = 0.0f;
    private float moveDuration = 0.0f;
    private float waitDuration = 0.0f;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        //DoMovement();
    }


    IEnumerator DoMovement()
    {
        yield return null;

        WaitForSeconds moveWait = new WaitForSeconds(moveDuration);
        WaitForSeconds waitWait = new WaitForSeconds(waitDuration);

        while (true)
        {
            //yield return waitWait;
        }
    }
}


