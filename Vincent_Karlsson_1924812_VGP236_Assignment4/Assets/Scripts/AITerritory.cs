using UnityEngine;

public class AITerritory : AIController
{
    private float _chaseTimer = 0.0f;
    private int _spawnC = 0;
    private int _spawnR = 0;


    public void Initialize(Transform target, int index)
    {
        base.Initialize(target);

        _spawnC = index % 19; // magic number
        _spawnR = index / 19;
    }

    protected override void Update()
    {
        switch (_state)
        {
            case State.Return:
                break;
            case State.Chase:
                break;
            default:
                break;
        }

        if (_chaseTimer > 0)
        {
            base.SetDestination(_target.position);

            _chaseTimer -= Time.deltaTime;
        }
        else
        {
            _chaseTimer = 0.0f;

            // Goes back to spawn point after chase comes to end
            SetDestination(new Vector3(_spawnC * 5, this.transform.position.y, _spawnR * 5));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _chaseTimer = 1.5f;
        }
    }

    protected void Chase()
    {
        base.SetDestination(_target.position);

        _chaseTimer -= Time.deltaTime;
    }
}
