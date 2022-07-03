using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speedMove;
    [SerializeField] private Player _player;

    private AnimationManager _animationManager;

    private Rigidbody _rb;
   
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animationManager = GetComponent<AnimationManager>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _speedMove, _rb.velocity.y, _joystick.Vertical * _speedMove);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);

            if (_player.CurrentCountItems > 0)
            {
                _animationManager.RunningObjects();
            }
            else
            {
                _animationManager.IsRun();
            }
        }
        else
        {
            _animationManager.Idle();
        }
    }
}
