using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController = null;
    [SerializeField] private Rigidbody2D _rg2D = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private GroundCheck _groundCheck = null;
    private bool _IsFacingRight = true;
    private float _moveDirection = 0.0f;

    private void Awake()
    {
        if (_playerController != null)
        {
            _playerController = gameObject.GetComponent<PlayerController>();
        }
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
        _moveDirection = _playerController.GetMovementInput().x;
        //_animator.SetBool("IsRunning", _moveDirection != 0);
        _animator.SetFloat("VeloX", Math.Abs(_moveDirection));

        // Flip
        if (Math.Abs(_moveDirection) > 0)
        {
            this.gameObject.transform.localScale = new Vector2(_moveDirection, 1);
        }

        _animator.SetFloat("VeloY", _rg2D.linearVelocityY);
        _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);

        // Check to see if this is technically better or worse performance wise
        //if (_groundCheck.IsGrounded == true)
        //{
        //    _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);
        //}
    }
}
