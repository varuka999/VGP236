using UnityEngine;

public class DebugPrint : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.0f;
    [SerializeField] private float _lifeTime = 0.0f;
    [SerializeField] private bool _firstUpdate = false;
    [SerializeField] private bool _firstFixedUpdate = false;

    private void Awake()
    {
        Debug.Log("Awake Debug Called");

    }

    private void OnEnable()
    {
        Debug.Log("OnEnable Debug Called");
    }

    void Start()
    {
        Debug.Log("Start Debug Called");
    }

    void Update()
    {
        if (_firstUpdate == false)
        {
            Debug.Log("Update Debug Called");
            _firstUpdate = true;
        }

        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_firstFixedUpdate == false)
        {
            Debug.Log("Fixed Update Debug Called");
            _firstFixedUpdate = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEntered2D Debug Called");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy Debug Called");
    }
}
