using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rg2D = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private GroundCheck _groundCheck = null;
    [SerializeField] private SlopeCheck _slopeCheck = null;
    private float _moveDirection = 0.0f;

    private void Awake()
    {
        if (_rg2D == null)
        {
            _rg2D = this.gameObject.GetComponent<Rigidbody2D>();
        }
        if (_animator == null)
        {
            _animator = this.gameObject.GetComponent<Animator>();
        }
        if (_groundCheck == null)
        {
            Debug.Log("Ground Check Ref Missing!!!");
        }
    }

    private void Update()
    {
        //_moveDirection = _playerController.GetMovementInput().x;

        //// Flip
        //if (Math.Abs(_moveDirection) > 0 && _moveDirection != this.transform.localScale.x)
        //{
        //    this.gameObject.transform.localScale = new Vector2(_moveDirection, 1);
        //}

        //_animator.SetFloat("VeloX", Math.Abs(_moveDirection));
        //_animator.SetFloat("VeloY", _rg2D.linearVelocityY);
        //_animator.SetBool("IsGrounded", _groundCheck.IsGrounded);

        // Check to see if this is technically better or worse performance wise
        //if (_groundCheck.IsGrounded == true)
        //{
        //    _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);
        //}
    }

    public void UpdateAnimations(float moveInput)
    {
        _moveDirection = moveInput;

        // Flip
        if (Math.Abs(_moveDirection) > 0 && _moveDirection != this.transform.localScale.x)
        {
            this.gameObject.transform.localScale = new Vector2(_moveDirection, 1);
        }

        _animator.SetFloat("VeloX", Math.Abs(_moveDirection));
        _animator.SetFloat("VeloY", _rg2D.linearVelocityY);
        _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);

        _animator.SetBool("IsOnSlope", _slopeCheck.ReturnIfOnSlope(moveInput));
    }
}
