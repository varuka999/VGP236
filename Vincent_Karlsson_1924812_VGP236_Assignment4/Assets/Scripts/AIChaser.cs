using UnityEngine;

public class AIChaser : AIController
{
    public override void Initialize(Transform target, int index)
    {
        base.Initialize(target, index);

        _state = State.Chase;
    }
}
