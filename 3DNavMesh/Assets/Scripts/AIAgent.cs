using System;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    enum BehaviorState
    {
        Wander,
        Seek,
    }

    public class WanderData
    {
        public float minUpdate = 3.0f;
        public float maxUpdate = 5.0f;
        public float currentUpdateTime = 0.0f;
        public float moveRange = 5.0f;
        public Vector3 centerPoint = Vector3.zero;
        public Vector3 currentTarget = Vector3.zero;
    }

    public class SeekData
    {
        public Vector3 lastTargetPosition = Vector3.zero;
        public float cantFindTime = 5.0f;
        public float currentCantFindTime = 0.0f;
    }

    [SerializeField] private GameObject _objective = null;
    [SerializeField] private float _viewDistance = 10.0f;
    [SerializeField] private NavMeshAgent _agent;
    BehaviorState _state = BehaviorState.Wander;
    private WanderData _wanderData = new WanderData();
    private SeekData _seekData = new SeekData();

    private void Awake()
    {
        if (_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
    }

    private void Update()
    {
        switch (_state)
        {
            case BehaviorState.Wander:
                DoWander();
                break;
            case BehaviorState.Seek:
                DoSeek();
                break;
            default:
                break;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    private void StartWander()
    {
        Vector2 radiusOffset = UnityEngine.Random.insideUnitCircle.normalized * _wanderData.moveRange;
        _wanderData.currentTarget.x = _wanderData.centerPoint.x + radiusOffset.x;
        _wanderData.currentTarget.z = _wanderData.centerPoint.z + radiusOffset.y; // y inside unit circle vector2
        _wanderData.currentTarget.y = _wanderData.centerPoint.y;
        _wanderData.currentUpdateTime = UnityEngine.Random.Range(_wanderData.minUpdate, _wanderData.maxUpdate);
        SetDestination(_wanderData.currentTarget);
        _state = BehaviorState.Wander;
    }

    private void StartSeek()
    {
        _seekData.lastTargetPosition = _objective.transform.position;
        SetDestination(_seekData.lastTargetPosition);

        _state = BehaviorState.Seek;
    }

    private bool CanSeeObjective()
    {
        if (_objective != null)
        {
            Vector3 direction = _objective.transform.position - transform.position;
            direction.Normalize();
            RaycastHit hitInfo;

            if (Physics.Raycast(transform.position, direction, out hitInfo, _viewDistance) == true)
            {
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.gameObject == _objective)
                    {
                        Debug.DrawLine(transform.position, hitInfo.point, Color.green, 1.0f);
                        return true;
                    }
                }
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + direction * _viewDistance, Color.red, 1.0f);
            }
        }

        return false;
    }

    private void DoWander()
    {
        _wanderData.currentUpdateTime -= Time.deltaTime;

        if (_wanderData.currentUpdateTime <= 0.0f || Vector3.Distance(transform.position, _wanderData.currentTarget) <= 1.0f)
        {
            Debug.Log("Started Wandering!");
            StartWander();
        }

        if (CanSeeObjective() == true)
        {
            StartSeek();
        }
    }

    private void DoSeek()
    {
        if (CanSeeObjective() == false)
        {
            _seekData.currentCantFindTime -= Time.deltaTime;

            if (_seekData.currentCantFindTime <= 0.0f)
            {
                DoWander();
            }
        }
        else
        {
            _seekData.currentCantFindTime = _seekData.cantFindTime;
            _seekData.lastTargetPosition = _objective.transform.position;
        }

        SetDestination(_seekData.lastTargetPosition);
    }
}