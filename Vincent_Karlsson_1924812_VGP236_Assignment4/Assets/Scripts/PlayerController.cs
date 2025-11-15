using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;

    public void Initialize()
    {
        //PlayerDestination.OnMouseClickEvent.AddListener(SetDestination);
        //PlayerDestination.OnMouseClickEvent += SetDestination;

        if (_agent == null)
        {
            _agent = this.GetComponent<NavMeshAgent>();
        }
    }

    private void Update()
    {

    }

    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
}
