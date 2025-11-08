using System.Collections;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _checkpointTextObj;
    private bool _hasTriggered = false;

    private IEnumerator CheckPointTrigger()
    {
        _checkpointTextObj.SetActive(true);

        yield return new WaitForSeconds(3);

        _checkpointTextObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _hasTriggered == false)
        {
            _hasTriggered = true;
            CheckpointManager.Instance.SetNewCheckpoint(this.transform);

            StartCoroutine(CheckPointTrigger());
        }
    }
}
