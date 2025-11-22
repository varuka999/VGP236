using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class AITerritory : AIController
{
    private float _chaseTimer = 0.0f;

    protected override void Update()
    {
        if (_chaseTimer > 0.0f)
        {
            _state = State.Chase;
        }
        else if (_state != State.Idle)
        {
            _state = State.Return;
        }

        base.Update();
    }

    protected override void DoChase()
    {
        base.DoChase();

        _chaseTimer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _chaseTimer = 1.5f;
        }
    }
}
