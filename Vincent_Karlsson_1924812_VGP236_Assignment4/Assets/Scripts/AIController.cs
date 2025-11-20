using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent = null;
    [SerializeField] protected Transform _target;

    [SerializeField] protected float _moveSpeed = 0.0f;
    [SerializeField] protected float _rotationSpeed = 0.0f;
    //[SerializeField] protected float _resetTimer = 0.0f;

    public virtual void Initialize(Transform target)
    {
        _target = target;
    }

    protected virtual void Update()
    {
        if (_agent != null)
        {
            SetDestination(_target.position);
        }
    }

    protected virtual void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
}