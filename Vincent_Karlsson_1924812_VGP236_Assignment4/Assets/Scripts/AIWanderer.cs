using UnityEngine;
using System.Collections.Generic;

public class AIWanderer : AIController
{
    private List<int> _validTargets = new List<int>();
    private Vector3 _targetVector3 = Vector3.zero;
    private float _findNewTargetTimer = 0;

    public void Initialize(List<int> list)
    {
        _validTargets.Clear();
        _validTargets.AddRange(list);
        _agent.speed = _moveSpeed;

        FindNewDestination();
    }

    protected override void Update()
    {
        _findNewTargetTimer -= Time.deltaTime;

        if (_findNewTargetTimer <= 0 || _targetVector3 == Vector3.zero)
        {
            FindNewDestination();
        }

        if (_targetVector3 != Vector3.zero)
        {
            base.SetDestination(_targetVector3);
        }
    }

    private void FindNewDestination()
    {
        int targetIndex = _validTargets[UnityEngine.Random.Range(0, _validTargets.Count)];
        int c = targetIndex % 19; // magic number :(
        int r = targetIndex / 19;

        _targetVector3 = new Vector3(c * 5, this.transform.position.y, r * 5);

        _findNewTargetTimer = 5.0f;
    }
}
