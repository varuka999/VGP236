using UnityEngine;

public class SlopeCheck : MonoBehaviour
{
    [SerializeField] private SlopeCheckCollision _slopeCheckRight = null;
    [SerializeField] private SlopeCheckCollision _slopeCheckLeft = null;
    [SerializeField] private Rigidbody2D _rg2D = null;
    [SerializeField] private PhysicsMaterial2D _noFrictionMaterial = null;
    [SerializeField] private PhysicsMaterial2D _fullFrictionMaterial = null;

    private void Awake()
    {
        if (_rg2D == null)
        {
            _rg2D = this.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    public void CheckIfOnSlope()
    {
        if (_slopeCheckRight.IsOnSlope)
        {
            if (_slopeCheckLeft.IsOnSlope)
            {
                _rg2D.sharedMaterial = _noFrictionMaterial;
            }
            else
            {
                _rg2D.sharedMaterial = _fullFrictionMaterial;
            }
        }
    }
}
