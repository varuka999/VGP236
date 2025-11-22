using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    protected enum State
    {
        Idle,
        Return,
        Wander,
        Chase,
    }

    [SerializeField] protected NavMeshAgent _agent = null;
    [SerializeField] protected Transform _target;

    [SerializeField] protected State _state = State.Idle;
    [SerializeField] protected float _moveSpeed = 0.0f;
    protected int _spawnC = 0;
    protected int _spawnR = 0;

    public virtual void Initialize(Transform target, int index)
    {
        _target = target;
        _state = State.Idle;
        _agent.speed = _moveSpeed;

        _spawnC = index % 19; // magic number
        _spawnR = index / 19;
    }

    protected virtual void Update()
    {
        switch (_state)
        {
            case State.Idle:
                DoIdle();
                break;
            case State.Return:
                DoReturn();
                break;
            case State.Chase:
                DoChase();
                break;
            case State.Wander:
                DoWander();
                break;
            default:
                break;
        }
    }

    protected virtual void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    protected virtual void DoIdle()
    {

    }

    protected virtual void DoChase()
    {
        SetDestination(_target.position);
    }

    protected virtual void DoReturn()
    {
        SetDestination(new Vector3(_spawnC * 5, this.transform.position.y, _spawnR * 5));

        if ((this.transform.position.x - _spawnC) + (this.transform.position.z - _spawnR) <= 1.0f)
        {
            _state = State.Idle;
        }
    }

    protected virtual void DoWander()
    {

    }
}