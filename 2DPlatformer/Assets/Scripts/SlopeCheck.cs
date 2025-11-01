using UnityEngine;

public class SlopeCheck : MonoBehaviour
{
    [SerializeField] private SlopeCheckCollision _slopeCheckRight = null;
    [SerializeField] private SlopeCheckCollision _slopeCheckLeft = null;
    [SerializeField] private Rigidbody2D _rg2D = null;
    [SerializeField] private PhysicsMaterial2D _noFrictionMaterial = null;
    [SerializeField] private PhysicsMaterial2D _fullFrictionMaterial = null;

    private bool _isOnSlope = false;

    private void Awake()
    {
        if (_rg2D == null)
        {
            _rg2D = this.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    public bool ReturnIfOnSlope(float moveInput)
    {
        if (_isOnSlope != _slopeCheckRight.IsOnSlope ? !_slopeCheckLeft.IsOnSlope : _slopeCheckLeft.IsOnSlope ? !_slopeCheckRight.IsOnSlope : false)
        {
            _isOnSlope = _slopeCheckRight.IsOnSlope ? !_slopeCheckLeft.IsOnSlope : _slopeCheckLeft.IsOnSlope ? !_slopeCheckRight.IsOnSlope : false;
        }

        if (moveInput == 0)
        {
            if (_isOnSlope == true)
            {
                _rg2D.sharedMaterial = _fullFrictionMaterial;
            }
            else if (_rg2D.sharedMaterial != _noFrictionMaterial)
            {
                _rg2D.sharedMaterial = _noFrictionMaterial;
            }
        }
        else
        {
            if (_rg2D.sharedMaterial != _noFrictionMaterial)
            {
                _rg2D.sharedMaterial = _noFrictionMaterial;
            }
        }

        return _isOnSlope;
    }
}
