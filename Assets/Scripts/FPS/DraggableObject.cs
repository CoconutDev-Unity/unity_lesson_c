using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DraggableObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _intialScale;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _follow;
    [SerializeField] private float _followSpeed = 15f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        if (!_follow)
            return;

        Vector3 moveDirection = _targetPosition - _rigidbody.position;
        _rigidbody.velocity = moveDirection * _followSpeed;
    }

    public void StartFollowingObject()
    {
        _follow = true;
    }

    public void SetTargetPosition(Vector3 newTargetPosition)
    {
        _targetPosition = newTargetPosition;
    }

    public void StopFollowingObject()
    {
        _follow = false;
        _rigidbody.velocity = Vector3.zero;
    }
}
